import { NgModule } from "@angular/core";
import { LogsTableComponent } from "./logs-table/logs-table.component";
import { TableModule } from "primeng/table";
import { CommonModule, DatePipe } from "@angular/common";

@NgModule({
    imports: [TableModule, CommonModule],
    providers: [],
    declarations: [LogsTableComponent],
    exports: [LogsTableComponent],
})
export class SharedComponentsModule {}
