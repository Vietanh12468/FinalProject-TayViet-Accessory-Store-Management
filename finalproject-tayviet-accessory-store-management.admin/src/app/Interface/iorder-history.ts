export interface IOrderHistory {
  id: string;
  customerID: string;
  shipLocation: string;
  cart: ProductInCart[];
  history: OrderHistoryMomento[];
}

interface OrderHistoryMomento {
  state: string;
  orderTime?: Date;
}

interface ProductInCart {
  productID: string;
  subProductList?: SubProductInCart[];
}

interface SubProductInCart {
  subProductName: string;
  cost: number;
  sale: number;
  quantity: number;
}
