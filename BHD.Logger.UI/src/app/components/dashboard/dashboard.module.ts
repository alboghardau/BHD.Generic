import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { DashboardComponent } from "./dashboard.component";
import { SharedModule } from "primeng/api";
import { SharedComponentsModule } from "../shared/shared-components.module";

@NgModule({
    declarations: [DashboardComponent],
    imports: [RouterModule.forChild([{ path: "", component: DashboardComponent }]), SharedComponentsModule],
})
export class DashboardModule {}
