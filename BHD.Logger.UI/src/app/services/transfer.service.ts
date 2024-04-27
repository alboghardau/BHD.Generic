import { Injectable, signal, Signal } from "@angular/core";

@Injectable({
    providedIn: 'root'
})
export class TransferService{

    //live page
    public isLivePage = signal<boolean>(true);
    public isLiveRunning = signal<boolean>(true);

    public toogleLivePooling(){
        this.isLiveRunning.set(!this.isLiveRunning());
    }


}