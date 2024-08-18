import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { IOrderHistory } from '../../Interface/iorder-history';
import { SelectOption } from '../../Interface/iselect-option';
import { OutputSearch } from '../../Interface/ioutput-search';
import { TableComponent } from '../../Component/table/table.component';
import { APIService } from '../../Service/API/api.service';
import { OrderHistoryMomento, ProductInCart, SubProductInCart } from '../../Interface/iorder-history';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-order-manager-view',
  templateUrl: './order-manager-view.component.html',
  styleUrls: ['./order-manager-view.component.css']
})
export class OrderManagerViewComponent implements OnInit {

  @ViewChild('tableComponent') tableComponent!: TableComponent;
  data: IOrderHistory[] = [];
  total: number = 0;
  mode = 'view';
  selectOptions: SelectOption[] = [
    {
      nameOption: 'OrderState',
      options: [
        'Processing',
        'Delivering',
        'Completed'
      ]
    }
  ]
  ignoredAttributes: string[] = ['Action'];
  detailLink = '';
  ];
  ignoredAttributes: string[] = [];
  detailLink = 'order-detail';

  constructor(private http: HttpClient, private snackBar: MatSnackBar) { }

  ngOnInit() {
    this.getCustomers();
  }
  constructor(private api: APIService, private http: HttpClient) { }

  getCustomers(page: number = 1) {
    this.http.get<any>(`/api/OrderHistory/page/${page}`).subscribe(
      (result) => {
        this.data = result.data;
        this.total = result.total;
        this.getOrderHistoryDisplay();
      },
      (error) => {
        console.error(error);
      }
    );
  }

  addOrderState(orderData: any) {
    console.log(orderData);
    this.api.addNewStateOrder(this.data[orderData.index].id, orderData.orderState).subscribe(
      (result) => {
        console.log(result);
        this.getCustomers();
      },
      (error) => {
        console.error(error);
      });

  }

  searchSubmit(searchInfo: OutputSearch) {
    this.http.get<any>(`/api/OrderHistory/search/username&&${searchInfo.searchString}&&${0}`).subscribe(
      (result) => {
        this.data = result.data;
        this.total = result.total;
        console.log(result);
      },
      (error) => {
        console.error(error);
      }
    );
  }

  onEditClick() {
    this.mode = 'change';
  }

  exitEditClick() {
    this.mode = 'view';
  }

  getOrderHistoryDisplay() {
    for (let order of this.data) {
      let orderHistoryDisplay: OrderHistoryDisplay = {
        orderID: order.id,
        total: 0,
        cartList: [],
        history: order.history
      }
      for (let product of order.cart) {
        this.api.getDetailObject('Product', product.productID).subscribe(
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
      this.OrderListDisplay.push(orderHistoryDisplay);
    }
    console.log(this.OrderListDisplay);
  }
  OrderListDisplay: OrderHistoryDisplay[] = []
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

  // Method to show save successful notification
  showSaveSuccessNotification() {
    this.snackBar.open('Save successful!', 'Close', {
      duration: 3000,
      verticalPosition: 'top',
      horizontalPosition: 'right',
    });
  }
  onSaveClick() {
    this.showSaveSuccessNotification();
  }
}
