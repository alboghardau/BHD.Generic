import { NgModule } from "@angular/core";
import { LiveViewComponent } from "./live-view.component";
import { LiveViewRoutingModule } from "./live-view-routing.module";
import { TableModule } from "primeng/table";
import { LogsTableComponent } from "../shared/logs-table/logs-table.component";

@NgModule({
    declarations: [
        LiveViewComponent,
        LogsTableComponent
    ],
    imports: [
        TableModule,
        LiveViewRoutingModule
    ],
    exports: []
})
export class LiveViewModule{

}