import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { LiveViewComponent } from "./live-view.component";

@NgModule({
    imports: [RouterModule.forChild([
        {path: '', component: LiveViewComponent}
    ])]
})
export class LiveViewRoutingModule{

}