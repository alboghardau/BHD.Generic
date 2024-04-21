import { NgModule } from "@angular/core";
import { LiveViewComponent } from "./live-view.component";
import { LiveViewRoutingModule } from "./live-view-routing.module";
import { TableModule } from "primeng/table";
import { LogsTableComponent } from "../shared/logs-table/logs-table.component";
import { SharedModule } from "primeng/api";
import { SharedComponentsModule } from "../shared/shared-components.module";

@NgModule({
    declarations: [
        LiveViewComponent        
    ],
    imports: [
        SharedComponentsModule,
        TableModule,
        LiveViewRoutingModule
    ],
    exports: []
})
export class LiveViewModule{

}