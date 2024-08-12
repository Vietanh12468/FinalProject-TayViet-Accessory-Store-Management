import { Component, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import { APIService } from '../../Service/API/api.service';
import { AuthenticationService } from '../../Service/Authentication/authentication.service';
import { OrderHistoryMomento, ProductInCart, SubProductInCart } from '../../Interface/iorder-history';
import { SubProduct } from '../../Interface/isub-product';
import { IOrderHistory } from '../../Interface/iorder-history';
import { IProduct } from '../../Interface/iproduct';
import { ICustomer } from '../../Interface/iaccount';

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrl: './history.component.css'
})
export class HistoryComponent implements OnInit, OnChanges {
  orderHistoryList: IOrderHistory[] = [];

  summary: any = {
    order: 0,
    delivery: 0,
    discount: 0,
    total: 0
  };
  userInfo: ICustomer = {} as ICustomer;

  constructor(private apiService: APIService, private authenticationService: AuthenticationService) { }

  ngOnInit() {
    this.getUserHistory();
    this.getOrderHistoryDisplay();
  }

  ngOnChanges(changes: SimpleChanges) {

  }

  ordredOrderListDisplay: OrderHistoryDisplay[] = []
  preparingOrderListDisplay: OrderHistoryDisplay[] = []
  completedOrderListDisplay: OrderHistoryDisplay[] = []
  otherOrderListDisplay: OrderHistoryDisplay[] = []

  getUserHistory() {
    const token = this.authenticationService.getToken();
    this.apiService.searchListObjects('OrderHistory', 'customerID', token.userID, 1).subscribe(
      (result) => {
        this.orderHistoryList = result.data;
        for (let order of this.orderHistoryList) {
          let orderHistoryDisplay: OrderHistoryDisplay = {
            orderID: order.id,
            total: 0,
            cartList: [],
            history: order.history
          }
          for (let product of order.cart) {
            this.apiService.getDetailObject('Product', product.productID).subscribe(
              (result) => {
                let productDisplay: CartProductDisplay = {
                  productID: result.id,
                  name: result.name,
                  image: result.image,
                  description: result.description,
                  subProductList: product.subProductList,
                  total: 0
                }
                for (let subProduct of product.subProductList) {
                  productDisplay.total += (subProduct.quantity * subProduct.cost) - (subProduct.quantity * subProduct.cost * subProduct.sale / 100);
                  orderHistoryDisplay.total += (subProduct.quantity * subProduct.cost) - (subProduct.quantity * subProduct.cost * subProduct.sale / 100);
                }
                orderHistoryDisplay.cartList.push(productDisplay);
              },
              (error) => {
                console.error(error);
              }
            );

          }
          let state = order.history[order.history.length - 1].state
          if (state === 'Ordered' || state === 'Complete Payment') {
            this.ordredOrderListDisplay.push(orderHistoryDisplay);
          }
          else if (state === 'Processing' || state === 'Out For Delivery') {
            this.preparingOrderListDisplay.push(orderHistoryDisplay);
          }
          else if (state === 'Delivered' || state === 'Complete Order') {
            this.completedOrderListDisplay.push(orderHistoryDisplay);
          }
          else{
            this.otherOrderListDisplay.push(orderHistoryDisplay);
          }
        }
      },
      (error) => {
        console.error(error);
      }
    );
    console.log(this.orderHistoryList);
  }

  getOrderHistoryDisplay() {

  }
}

interface CartProductDisplay {
  productID: string;
  name: string;
  image: string;
  description: string;
  subProductList: SubProductInCart[];
  total: number;
}

interface OrderHistoryDisplay {
  orderID: string | undefined;
  total: number;
  cartList: CartProductDisplay[];
  history: OrderHistoryMomento[];
}
