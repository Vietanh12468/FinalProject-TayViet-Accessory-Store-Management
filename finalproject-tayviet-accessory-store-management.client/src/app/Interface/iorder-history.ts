export interface IOrderHistory {
  id?: string ;
  customerID: string;
  shipLocation: string;
  cart: ProductInCart[];
  history: OrderHistoryMomento[];
}

export interface OrderHistoryMomento {
  state: string;
  orderTime?: Date;
}

export interface ProductInCart {
  productID: string;
  subProductList: SubProductInCart[];
}

export interface SubProductInCart {
  subProductName: string;
  cost: number;
  sale: number;
  quantity: number;
}
