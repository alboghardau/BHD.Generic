import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable({
    providedIn: "root",
})
export class ConfigurationService {
    private config: any;

    constructor(private http: HttpClient) {}

    loadConfig(): Promise<any> {
        return this.http
            .get("app.config.json")
            .toPromise()
            .then((data) => {
                this.config = data;
                console.log("Configuration loaded");
            })
            .catch((error) => {
                console.error("Failed to load configuration", error);
            });
    }

    get baseUrl(): string {
        return this.config.baseUrl;
    }
}
