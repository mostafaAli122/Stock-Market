import { IStock } from '../market/stock.interface';

export interface IOrderResponse {
  id:number;
  quantity: number;
  price: number;
  personName: string;
  stockName: string;
}
export interface IOrder {
  id: number;
  stock: IStock | null;
  quantity: number;
  price: number;
  personName: string;

  stockId?: number;
  createdBy?: string;
  updatedBy?: string;
  createTime?: string;
  updateTime?: string;
  isActive?: boolean;
  isDeleted?: boolean;
}

export class Order implements IOrder {
  id: number = 0;
  stock: IStock | null = null;
  quantity: number = 0;
  price: number = 0;
  personName: string = '';
}
