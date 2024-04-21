import { Component, Input, OnInit } from "@angular/core";
import { Log } from "src/app/models/log.model";
import { LogsService } from "src/app/services/logs.service";
import {TableModule} from "primeng/table";

@Component({
    selector: "logs-table",
    templateUrl: "./logs-table.component.html",
    styleUrls: ["./logs-table.component.scss"],
})
export class LogsTableComponent{
    constructor(private logsService: LogsService) {}

    public tableSize: string = "p-datatable-sm";

    @Input() logs: Log[] = [];


}
