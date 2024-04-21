import { NgModule } from "@angular/core";
import { LogsTableComponent } from "./logs-table/logs-table.component";
import { TableModule } from "primeng/table";

@NgModule({
    imports: [TableModule],
    declarations: [LogsTableComponent],
    exports: [LogsTableComponent]
})
export class SharedComponentsModule{

}