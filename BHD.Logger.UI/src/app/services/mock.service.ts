import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { ConfigurationService } from "./configuration.service";
import { START_MOCK_API, STOP_MOCK_API } from "../common/apiUrls";

@Injectable({
    providedIn: "root",
})
export class MockService {
    constructor(
        private httpClient: HttpClient,
        private config: ConfigurationService
    ) {}

    public startMock() {
        this.httpClient
            .post(this.config.baseUrl + START_MOCK_API, "")
            .subscribe(() => {});
    }

    public stopMock() {
        this.httpClient
            .post(this.config.baseUrl + STOP_MOCK_API, "")
            .subscribe(() => {});
    }
}
