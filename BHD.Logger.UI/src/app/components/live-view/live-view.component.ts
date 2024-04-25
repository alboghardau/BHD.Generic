import { Component, OnDestroy, OnInit } from "@angular/core";
import { EMPTY, Subscription, switchMap, timer } from "rxjs";
import { LogsDataService } from "src/app/data-access/logs-data.service";
import { LiveResponseDto } from "src/app/models/dtos/live-response-dto.model";
import { Log } from "src/app/models/log.model";
import { LogsService } from "src/app/services/logs.service";

@Component({
  selector: "live-view",
  templateUrl: "./live-view.component.html",
})
export class LiveViewComponent implements OnInit, OnDestroy {
  public logs: Log[] = [];
  private logsSubscription?: Subscription;
  private isFirstCall = true;
  private latestTime: Date = new Date();
  private readonly pollingInterval = 1000; // 2 seconds
  private readonly maxLogsCount = 1000;

  constructor(private logsService: LogsDataService) {}

  ngOnInit(): void {
    this.latestTime = this.getUtcMinusOne();
    this.fetchData();
    this.isFirstCall = false;
    this.startPolling();
  }

  ngOnDestroy(): void {
    this.stopPolling();
  }

  private startPolling(): void {
    this.logsSubscription = timer(0, this.pollingInterval)
      .pipe(
        switchMap(() => {
          this.fetchData();
          return EMPTY;
        })
      )
      .subscribe(() => {
        
      });
  }

  private fetchData() {
    this.logsService
      .getLiveLogs(this.latestTime, this.isFirstCall)
      .subscribe((data: LiveResponseDto) => {
        if (data.logs.length > 0) {
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

  private getUtcMinusOne(): Date {
    let time = new Date();
    const timeUtc = time.getUTCHours() - 1;
    time.setUTCHours(timeUtc);

    return time;
  }
}
