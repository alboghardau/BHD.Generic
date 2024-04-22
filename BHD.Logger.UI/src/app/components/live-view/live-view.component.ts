import { Component, OnInit } from "@angular/core";
import { Subscription } from "rxjs";
import { LogsDataService } from "src/app/data-access/logs-data.service";
import { LiveResponseDto } from "src/app/models/dtos/live-response-dto.model";
import { Log } from "src/app/models/log.model";
import { LogsService } from "src/app/services/logs.service";

@Component({
    selector: "live-view",
    templateUrl: "./live-view.component.html"
})
export class LiveViewComponent implements OnInit{
    
    public logs: Log[] = []
    private logsSubscription?: Subscription;
    private isFirstCall = false;
    private latestTime: Date = new Date();

    constructor(private logsService: LogsDataService){

    }

    ngOnInit(): void {
        this.latestTime = this.getUtcMinusOne();

        this.fetchLiveLogs(this.latestTime, this.isFirstCall)
    }

    private getUtcMinusOne(): Date{
        let time = new Date();
        const timeUtc = time.getUTCHours() - 1;
        time.setUTCHours(timeUtc);

        return time;
    }

    private fetchLiveLogs(latestTime: Date, isFirstCall: boolean){
        this.logsService.getLiveLogs(latestTime, isFirstCall).subscribe( (data:LiveResponseDto) => {
            this.logs = data.logs;
            this.latestTime = data.latestTime;
        });
    }
    
}

