import { Component, OnInit } from "@angular/core";
import { Log } from "src/app/models/log.model";
import { LogsService } from "src/app/services/logs.service";

@Component({
    selector: "logs-table",
    templateUrl: "./logs-table.component.html",
    styleUrls: ["./logs-table.component.scss"],
})
export class LogsTableComponent implements OnInit {
    constructor(private logsService: LogsService) {}

    public tableSize: string = "p-datatable-sm";

    public logs: Log[] = [];

    ngOnInit(): void {
        // setInterval(() => {
        //     this.updateLogs();
        // }, 2000);
    }

    private updateLogs() {
        this.logs = this.logsService.getAllLogs();
    }
}
