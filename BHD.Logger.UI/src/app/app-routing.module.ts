import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { AppLayoutComponent } from "./components/layout/app.layout.component";
import { LiveViewComponent } from "./components/live-view/live-view.component";

@NgModule({
imports: [
    RouterModule.forRoot([{
        path: '', component: AppLayoutComponent,
        children: [
            {path: '', component: LiveViewComponent}
        ]
    }])
],
exports: [RouterModule]
})
export class AppRoutingModule{

}