import { NgModule } from "@angular/core";
import { LogsTableComponent } from "./logs-table/logs-table.component";
import { TableModule } from "primeng/table";
import { CommonModule, DatePipe } from "@angular/common";
import { ChartModule } from "primeng/chart";
import { LineChartComponent } from "./charts/line-chart/line-chart.component";

@NgModule({
    imports: [TableModule, CommonModule, ChartModule],
    providers: [],
    declarations: [LogsTableComponent, LineChartComponent],
    exports: [LogsTableComponent, LineChartComponent],
})
export class SharedComponentsModule {}
