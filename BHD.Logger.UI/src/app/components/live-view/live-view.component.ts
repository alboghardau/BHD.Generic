import { Component } from "@angular/core";
import { Log } from "src/app/models/log.model";

@Component({
    selector: "live-view",
    templateUrl: "./live-view.component.html"
})
export class LiveViewComponent{
    
    public logs: Log[] = [{
        time: new Date(),
        message: "bla bla"
    },
    {
        time: new Date(),
        message: "bla bla"
    },
    {
        time: new Date(),
        message: "bla bla"
    },
    {
        time: new Date(),
        message: "bla bla"
    },
    {
        time: new Date(),
        message: "bla bla"
    }
];



}

