import { APP_INITIALIZER, NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";

import { AppComponent } from "./app.component";
import { OptionsBarComponent } from "./components/options-bar/options-bar.component";
import { LogsTableComponent } from "./components/logs-table/logs-table.component";
import { HttpClient, HttpClientModule } from "@angular/common/http";
import { ConfigurationService } from "./services/configuration.service";

export function initConfiguration(service: ConfigurationService) {
    return (): Promise<any> => {
        return service.loadConfig();
    };
}
@NgModule({
    declarations: [AppComponent, OptionsBarComponent, LogsTableComponent],
    imports: [BrowserModule, HttpClientModule],
    providers: [
        {
            provide: APP_INITIALIZER,
            useFactory: initConfiguration,
            deps: [ConfigurationService],
            multi: true,
        },
    ],
    bootstrap: [AppComponent],
})
export class AppModule {}
