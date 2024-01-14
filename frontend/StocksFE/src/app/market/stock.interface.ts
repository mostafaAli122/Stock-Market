export interface IStock {
  id: number;
  name: string;
  price: number;
  quantity?: number;

  createdBy?: number | null;
  updatedBy?: number | null;
  createTime?: string | null;
  updateTime?: string | null;
  isActive?: boolean | null;
  isDeleted?: boolean | null;
}
