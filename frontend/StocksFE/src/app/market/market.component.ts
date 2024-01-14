import { OrderService } from './../orders/order.service';
import { Component, Input, OnInit, Pipe, inject } from '@angular/core';
import { IStock } from './stock.interface';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MarketService } from './market.service';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { SignalRService } from '../signal-r.service';

@Component({
  selector: 'app-market',
  standalone: true,
  imports: [CommonModule, FormsModule],
  providers: [SignalRService],
  templateUrl: './market.component.html',
  styleUrl: './market.component.scss',
})
export class MarketComponent {
  @Input() canOrder: boolean = false;
  stocks: IStock[] = [];
  orderService = inject(OrderService);
  marketService = inject(MarketService);
  signalRService = inject(SignalRService);
  constructor() {
    this.signalRService.buildConnection();
    this.signalRService.startConnection();
    this.signalRService
      .getStockData()
      .pipe(takeUntilDestroyed())
      .subscribe((res) => {
         this.stocks = res
      });

    this.getAllStocks();
  }
 

  orderStock(stock: IStock) {
    if (stock.quantity! > 0) this.orderService.setOrderStock(stock);
  }

  getAllStocks() {
    this.marketService
      .getAllStocks()
      .pipe(takeUntilDestroyed())
      .subscribe((res) => {
        this.stocks = res;
      });
  }
}
