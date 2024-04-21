import { Injectable } from "@angular/core";
import { Log } from "../models/log.model";
import { ConfigurationService } from "./configuration.service";
import { LogsDataService } from "../data-access/logs-data.service";

@Injectable({
    providedIn: "root",
})
export class LogsService {
    private logs: Log[] = [];

    constructor(
        private config: ConfigurationService,
        private logsDataService: LogsDataService
    ) {}

    public getAllLogs(): Log[] {
        if (this.logs.length == 0) {
            
        }

        return this.logs;
    }

    public addLog(log: Log): void {
        this.logs.push(log);
    }

    public clearLogs(): void {
        this.logs = [];
    }

    
}
