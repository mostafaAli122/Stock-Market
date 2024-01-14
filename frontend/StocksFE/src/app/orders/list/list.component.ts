import { Component, OnDestroy, inject } from '@angular/core';
import { IOrder, IOrderResponse } from '../order.interface';
import { CommonModule } from '@angular/common';
import {
  NgbActiveModal,
  NgbModal,
  NgbModule,
} from '@ng-bootstrap/ng-bootstrap';
import { AddNewOrderComponent } from '../add-new-order/add-new-order.component';
import { OrderService } from '../order.service';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-list',
  standalone: true,
  imports: [CommonModule, NgbModule],
  templateUrl: './list.component.html',
  styleUrl: './list.component.scss',
  providers: [NgbActiveModal],
})
export class ListComponent implements OnDestroy {
  orders: IOrderResponse[] = [];
  subscription: Subscription = new Subscription();
  activeModal = inject(NgbActiveModal);
  private modalService = inject(NgbModal);
  constructor(private orderService: OrderService) {
    this.orderService
      .getOrder()
      .pipe(takeUntilDestroyed())
      .subscribe((res) => {
        if (res) {
          this.createNewOrder(res);
        }
      });
    this.getAllOrders();
  }
  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  createNewOrder(order: IOrder) {
    order.stockId = order.stock?.id;
    this.subscription.add(
      this.orderService.createNewOrder(order).subscribe((res) => {
        if (res) {
          this.orders.push(res);
          this.orderService.setOrder(null);
        }
      })
    );
  }
  openAddNewOrder() {
    const modalRef = this.modalService.open(AddNewOrderComponent, {
      centered: true,
      keyboard: false,
      backdrop: 'static',
    });
  }

  getAllOrders() {
    this.orderService
      .getAllOrder()
      .pipe(takeUntilDestroyed())
      .subscribe((res) => {
        if (res) {
          this.orders = res;
        }
      });
  }
}
