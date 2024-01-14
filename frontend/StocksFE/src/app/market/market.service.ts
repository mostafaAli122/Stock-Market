 import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { IStock } from './stock.interface';

@Injectable({
  providedIn: 'root',
})
export class MarketService {
  httpClient = inject(HttpClient);
 

  getAllStocks() {
    // let headers = new HttpHeaders(); //.set('access-control-allow-origin',"http://localhost:4200/");
    // headers.append('Access-Control-Allow-Origin', 'http://localhost:4200');
    // headers.append('Access-Control-Allow-Credentials', 'true');
    return this.httpClient.get<IStock[]>('http://localhost:5115/api/Stock', {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
    });
  }
}
