import { Component, OnInit } from "@angular/core";
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
    private isFirstCall = false;
    private latestTime?: Date;

    constructor(private logsService: LogsDataService){

    }

    ngOnInit(): void {
        this.logsService.getLiveLogs(new Date(), true).subscribe( (data:LiveResponseDto) => {
            this.logs = data.logs;
            this.latestTime = data.latestTime;
        });
    }


}

