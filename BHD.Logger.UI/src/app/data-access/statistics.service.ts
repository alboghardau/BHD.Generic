import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ConfigurationService } from "../services/configuration.service";
import { GET_LAST_HOUR_STATS } from "../common/apiUrls";
import { Observable } from "rxjs";
import { LineChartData } from "../components/shared/charts/line-chart/line-chart-data.model";

@Injectable({
    providedIn: "root"
})
export class StatisticsService{
    constructor(
        private http: HttpClient,
        private config: ConfigurationService
    ) {}

    public getLastHourStats(): Observable<LineChartData>{
        const url = this.config.baseUrl + GET_LAST_HOUR_STATS;

        return this.http.get<LineChartData>(url);
    }
}