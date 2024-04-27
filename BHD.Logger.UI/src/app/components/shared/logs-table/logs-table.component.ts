import { Component, Input, OnInit } from "@angular/core";
import { Log } from "src/app/models/log.model";
import { LogLevel } from "src/app/enums/loglevel.enum";

@Component({
    selector: "logs-table",
    templateUrl: "./logs-table.component.html",
    styleUrls: ["./logs-table.component.scss"],
})
export class LogsTableComponent {
    constructor() {}

    public tableSize: string = "p-datatable-sm";

    @Input() logs: Log[] = [];

    public getLogLevelByValue(value: LogLevel): string | undefined {
        const enumKey = LogLevel[value];
        return enumKey;
    }
}
