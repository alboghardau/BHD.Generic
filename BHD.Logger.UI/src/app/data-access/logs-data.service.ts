import { Injectable } from "@angular/core";
import { ConfigurationService } from "../services/configuration.service";
import { HttpClient } from "@angular/common/http";
import { GET_ALL_LOGS } from "../common/apiUrls";
import { Log } from "../models/log.model";
import { Observable, lastValueFrom } from "rxjs";

@Injectable({
    providedIn: "root",
})
export class LogsDataService {
    constructor(
        private http: HttpClient,
        private config: ConfigurationService
    ) {}

    public async getAllLogs(): Promise<Log[]> {
        const request = this.http.get<Log[]>(
            this.config.baseUrl + GET_ALL_LOGS
        );
        const response = lastValueFrom(request);
        return response;
    }
}
