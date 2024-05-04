import { Injectable } from "@angular/core";
import { ConfigurationService } from "../services/configuration.service";
import { HttpClient } from "@angular/common/http";
import { GET_LAST_CRITICAL, GET_LIVE_LOGS } from "../common/apiUrls";
import { Log } from "../models/log.model";
import { Observable, lastValueFrom } from "rxjs";
import { LiveRequestDto } from "../models/dtos/live-request-dto.model";
import { Time } from "@angular/common";
import { LiveResponseDto } from "../models/dtos/live-response-dto.model";

@Injectable({
    providedIn: "root",
})
export class LogsDataService {
    constructor(private http: HttpClient, private config: ConfigurationService) {}

    public getLiveLogs(
        requestTime: Date,
        isFirstCall: boolean = false
    ): Observable<LiveResponseDto> {
        const url = this.config.baseUrl + GET_LIVE_LOGS;
        const body: LiveRequestDto = {
            requestTime: requestTime,
            isFirstCall: isFirstCall,
        };

        return this.http.post<LiveResponseDto>(url, body);
    }

    public getLastCritical(): Observable<Log[]>{
        const url = this.config.baseUrl + GET_LAST_CRITICAL;

        return this.http.get<Log[]>(url);
    }
}
