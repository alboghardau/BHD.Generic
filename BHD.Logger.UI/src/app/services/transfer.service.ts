import { Injectable, signal, Signal } from "@angular/core";

@Injectable({
    providedIn: 'root'
})
export class TransferService{

    //live page
    public isLivePage = signal<boolean>(false);
    public isLiveRunning = signal<boolean>(false);

    public toogleLivePooling(){
        this.isLiveRunning.set(!this.isLiveRunning());
    }


}