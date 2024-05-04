import { Component, OnInit } from "@angular/core";
import { ChartData, ChartOptions } from "chart.js";
import { StatisticsService } from "src/app/data-access/statistics.service";
import { LineChartData } from "../shared/charts/line-chart/line-chart-data.model";
import { LogsDataService } from "src/app/data-access/logs-data.service";
import { Log } from "src/app/models/log.model";

@Component({
    selector: "dashboard-component",
    templateUrl: "./dashboard.component.html",
})
export class DashboardComponent implements OnInit {
    public chartData: LineChartData | undefined;
    public lastCriticalLogs: Log[] = [];

    constructor(private statsService: StatisticsService, private logsService: LogsDataService) {}

    ngOnInit(): void {
        //chart data
        this.statsService.getLastHourStats().subscribe((data: LineChartData) => {
            this.chartData = data;
        });

        //table data
        this.logsService.getLastCritical().subscribe ( (data: Log[]) => {
            this.lastCriticalLogs = data;
        })
    }
}
