import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { BehaviorSubject, Subject } from 'rxjs';
import * as signalR from '@aspnet/signalr';
import { IStock } from './market/stock.interface';

@Injectable({
  providedIn: 'root',
})
export class SignalRService {
  setStockData(data: IStock[]) {
    this.stockPriceReceived$.next(data);
  }
  getStockData() {
    return this.stockPriceReceived$.asObservable();
  }
  private hubConnection!: signalR.HubConnection;
  private stockPriceReceived$ = new Subject<IStock[]>();

  constructor() {
    // this.buildConnection();
    // this.startConnection();
  }

  buildConnection() {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('http://localhost:5115/StockHub') // Replace with your API base URL
      .build();

    this.hubConnection.on('ReceiveStockPrices', (data: IStock[]) => {
      this.stockPriceReceived$.next(data);
    });
  }

  startConnection() {
    this.hubConnection
      .start()
      .then(() => {})
      .catch((err: any) =>
        console.error('Error while starting connection: ', err)
      );
  }
}
