import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { AppLayoutComponent } from "./components/layout/app.layout.component";

@NgModule({
imports: [
    RouterModule.forRoot([{
        path: '', component: AppLayoutComponent,
        children: [
            {path: '', loadChildren: () => import('./components/live-view/live-view.module').then(m => m.LiveViewModule)},
            {path: 'dashboard', loadChildren: () => import('./components/dashboard/dashboard.module').then(m => m.DashboardModule)}
        ]
    }])
],
exports: [RouterModule]
})
export class AppRoutingModule{

}