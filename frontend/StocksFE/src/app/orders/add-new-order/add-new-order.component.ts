import { OrderService } from './../order.service';
import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgbActiveModal, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { IOrder, Order } from '../order.interface';
import { MarketComponent } from '../../market/market.component';
import { Subscription } from 'rxjs';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add-new-order',
  standalone: true,
  imports: [CommonModule, NgbModule, FormsModule, MarketComponent],
  templateUrl: './add-new-order.component.html',
  styleUrl: './add-new-order.component.scss',
})
export class AddNewOrderComponent {
  order: IOrder = new Order();
  activeModal = inject(NgbActiveModal);
  toastrService = inject(ToastrService);
  subs: Subscription = new Subscription();
  //private modalService = inject(NgbModal);
  constructor(private orderService: OrderService) {
    this.subs.add(
      this.orderService
        .getOrderStock()
        .pipe(takeUntilDestroyed())
        .subscribe((res) => {
          if (res) {
            if (!this.order.personName) {
              this.toastrService.error('Person name is required');
            } else {
              this.order.stock = res;
              this.order.quantity = res.quantity!;
              this.order.price = res.price;
              this.orderService.setOrder(this.order);
            }
          }
        })
    );
  }
}
