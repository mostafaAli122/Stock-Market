import { Injectable, inject } from '@angular/core';
import { IStock } from '../market/stock.interface';
import { BehaviorSubject } from 'rxjs';
import { IOrder, IOrderResponse } from './order.interface';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class OrderService {
  orderStock$: BehaviorSubject<IStock | null> =
    new BehaviorSubject<IStock | null>(null);

  httpClient = inject(HttpClient);

  constructor() {}

  setOrderStock(stock: IStock | null) {
    this.orderStock$.next(stock);
  }

  getOrderStock() {
    return this.orderStock$.asObservable();
  }

  order$: BehaviorSubject<IOrder | null> = new BehaviorSubject<IOrder | null>(
    null
  );

  setOrder(order: IOrder | null) {
    this.order$.next(order);
  }

  getOrder() {
    return this.order$.asObservable();
  }

  getAllOrder() {
    return this.httpClient.get<IOrderResponse[]>('http://localhost:5115/api/Order', {});
  }

  createNewOrder(order: IOrder) {
    return this.httpClient.post<IOrderResponse>(
      'http://localhost:5115/api/Order',
      order
    );
  }
}
