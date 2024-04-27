import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { LiveViewComponent } from "./live-view.component";
import { DashboardComponent } from "../darshboard/dashboard.component";

@NgModule({
    imports: [RouterModule.forChild([
        {path: '', component: LiveViewComponent},
        {path: 'dashboard', component: DashboardComponent}
    ])]
})
export class LiveViewRoutingModule{

}