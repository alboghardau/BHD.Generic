import { Injectable } from "@angular/core";
import { Log } from "../models/log";
import { ConfigurationService } from "./configuration.service";
import { LogsDataService } from "../data-access/logs-data.service";
import { lastValueFrom } from "rxjs";

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
            this.retrieveAllLogs();
        }

        return this.logs;
    }

    public addLog(log: Log): void {
        this.logs.push(log);
    }

    public clearLogs(): void {
        this.logs = [];
    }

    private retrieveAllLogs() {
        this.logsDataService
            .getAllLogs()
            .then((data) => {
                this.logs = data;
            })
            .catch((error) => {
                console.error(error);
                throw error;
            });
        console.log(this.logs);
    }
}
