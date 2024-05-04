import { NgModule } from "@angular/core";
import { LiveViewComponent } from "./live-view.component";
import { TableModule } from "primeng/table";
import { LogsTableComponent } from "../shared/logs-table/logs-table.component";
import { SharedModule } from "primeng/api";
import { SharedComponentsModule } from "../shared/shared-components.module";
import { ChartModule } from "primeng/chart";
import { RouterModule } from "@angular/router";

@NgModule({
    declarations: [LiveViewComponent],
    imports: [
        RouterModule.forChild([{ path: "", component: LiveViewComponent }]),
        SharedComponentsModule,
        TableModule,
    ],
    exports: [],
})
export class LiveViewModule {}
