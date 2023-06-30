import { Component, OnInit } from "@angular/core";
import { MockService } from "src/app/services/mock.service";

@Component({
    selector: "options-bar",
    templateUrl: "./options-bar.component.html",
    styleUrls: ["./options-bar.component.scss"],
})
export class OptionsBarComponent implements OnInit {
    private mockService;

    constructor(mockService: MockService) {
        this.mockService = mockService;
    }

    ngOnInit(): void {}

    public startMock() {
        this.mockService.startMock();
    }

    public stopMock() {
        this.mockService.stopMock();
    }
}
