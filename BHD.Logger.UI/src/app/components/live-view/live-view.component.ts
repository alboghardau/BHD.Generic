import { Component, OnDestroy, OnInit } from "@angular/core";
import { Subscription, switchMap, timer } from "rxjs";
import { LogsDataService } from "src/app/data-access/logs-data.service";
import { LiveResponseDto } from "src/app/models/dtos/live-response-dto.model";
import { Log } from "src/app/models/log.model";
import { LogsService } from "src/app/services/logs.service";

@Component({
    selector: "live-view",
    templateUrl: "./live-view.component.html"
})
export class LiveViewComponent implements OnInit, OnDestroy{
    
    public logs: Log[] = []
    private logsSubscription?: Subscription;
    private isFirstCall = false;
    private latestTime: Date = new Date();
    private readonly pollingInterval = 500; // 2 seconds
    private readonly maxLogsCount = 1000;


    constructor(private logsService: LogsDataService){

    }

    ngOnInit(): void {
        this.latestTime = this.getUtcMinusOne();
        this.startPolling();
    }

    ngOnDestroy(): void{
        this.startPolling();
    }

    private startPolling(): void {
        this.logsSubscription = timer(0, this.pollingInterval).pipe(
          switchMap(() => this.logsService.getLiveLogs(this.latestTime))
        ).subscribe((data: LiveResponseDto) => {
          if(data.logs.length > 0){
            this.logs.unshift(...data.logs);
            this.latestTime = data.latestTime;
          }
          if (this.logs.length > this.maxLogsCount) {
            this.logs = this.logs.slice(0, this.maxLogsCount);
          }
        });
    }

    private stopPolling(): void {
    if (this.logsSubscription) {
        this.logsSubscription.unsubscribe();
        }
    }

    private getUtcMinusOne(): Date{
        let time = new Date();
        const timeUtc = time.getUTCHours() - 1;
        time.setUTCHours(timeUtc);

        return time;
    }    
}

