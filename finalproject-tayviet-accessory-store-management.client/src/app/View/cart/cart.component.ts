import { Component, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import { APIService } from '../../Service/API/api.service';
import { AuthenticationService } from '../../Service/Authentication/authentication.service';
import { ProductInCart, SubProductInCart, IOrderHistory } from '../../Interface/iorder-history';
import { SubProduct } from '../../Interface/isub-product';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.css'
})
export class CartComponent implements OnInit, OnChanges {
  cartList: ProductInCart[] = [
    {
      productID: '',
      subProductList: []
    }
  ];
  productDisplayList: CartProductDisplay[] = [];
  paymentOption = 'PayOnDelivery'
  summary: any = {
    order: 0,
    delivery: 0,
    discount: 0,
    total: 0
  };
  userInfo: any
  shipLocation: string = 'ghost address';

  constructor(private apiService: APIService, private authenticationService: AuthenticationService, private snackBar: MatSnackBar) { }

  ngOnInit() {
    if (this.authenticationService.isLoggedIn() === true) {
      this.getUserCart();

    }
  }

  ngOnChanges(changes: SimpleChanges) {
    for (let productDisplay of this.productDisplayList) {
      this.summary.total += productDisplay.total;
    }
  }

  getUserCart() {
    const token = this.authenticationService.getToken();
    this.apiService.getDetailObject('Customer', token.userID).subscribe(
      (result) => {
        this.cartList = result.cartList;
        this.userInfo = result;
        this.getProductDisplayList();
      },
      (error) => {
        console.error(error);
      }
    );
  }

  getProductDisplayList() {
    for (let i = 0; i < this.cartList.length; i++) {
      this.apiService.getDetailObject('Product', this.cartList[i].productID).subscribe(
        (result) => {
          let productDisplay: CartProductDisplay = {
            productID: result.id,
            name: result.name,
            image: result.image,
            description: result.description,
            subProductList: [],
            total: 0
          }
          for (let subProduct of this.cartList[i].subProductList) {
            const item: SubProduct = result.subProductList.find((item: SubProduct) => item.name === subProduct.subProductName);
            if (!item) {
              throw new Error('Item not found');
            }
            let subProductInCart: SubProductInCart = { subProductName: item.name, cost: item.sellCost, sale: item.discount, quantity: subProduct.quantity };
            productDisplay.subProductList.push(subProductInCart);
            productDisplay.total += item.sellCost * subProduct.quantity * (1 - item.discount / 100);
          }
          this.productDisplayList.push(productDisplay);
          this.caculateTotal();
        },
        (error) => {
          console.error(error);
        }
      );
    }
  }

  deleteSubProduct(productID: string, subProductName: string) {
    this.productDisplayList.forEach((productDisplay) => {
      if (productDisplay.productID === productID) {
        productDisplay.subProductList = productDisplay.subProductList.filter((subProduct) => subProduct.subProductName !== subProductName);
        this.cartList.forEach((product) => {
          if (product.productID === productID) {
            product.subProductList = product.subProductList.filter((subProduct) => subProduct.subProductName !== subProductName);
          }
        });
      }
      if (productDisplay.subProductList.length === 0) {
        this.productDisplayList = this.productDisplayList.filter((productDisplay) => productDisplay.productID !== productID);
        this.cartList = this.cartList.filter((product) => product.productID !== productID);
      }
    });
    this.caculateTotal();
    this.userInfo = { ...this.userInfo, cartList: this.cartList };
    console.log(this.userInfo);
    this.apiService.changeDetailObject('Customer', this.userInfo).subscribe(
      (result) => {
        console.log(result);
      },
      (error) => {
        console.error(error);
      }
    );
  }

  caculateTotal() {
    this.summary = {
      order: 0,
      delivery: 0,
      discount: 0,
      total: 0
    }
    for (let productDisplay of this.productDisplayList) {
      for (let subProduct of productDisplay.subProductList) {
        this.summary.total += ((subProduct.cost * subProduct.quantity) - (subProduct.cost * subProduct.quantity * subProduct.sale / 100)) + 1;
        this.summary.order += subProduct.cost * subProduct.quantity;
        this.summary.delivery += 1;
        this.summary.discount += subProduct.cost * subProduct.quantity * subProduct.sale / 100;
      }
    }
  }

  orderSubmit() {

    const orderHistory: IOrderHistory = {
      customerID: this.userInfo.id,
      shipLocation: this.shipLocation,
      cart: this.cartList,
      history: [
        {
          state: 'Ordered'
        }
      ],
    }
    this.apiService.createDetailObject('OrderHistory', orderHistory).subscribe(
      (result) => {
        this.userInfo.cartList = [];
        this.apiService.changeDetailObject('Customer', this.userInfo).subscribe(
          (result) => {
            this.snackBar.open('Order Successful', 'Close', {
              duration: 10000,
              verticalPosition: 'top',
              horizontalPosition: 'right',
            });
          },
          (error) => {
            console.error(error);
          }
        );
        console.log(result);

      },
      (error) => {
        console.error(error);
      }
    );
  }
}

interface CartProductDisplay {
  productID: string;
  name: string;
  image: string;
  description: string;
  subProductList: SubProductInCart[]
  total: number
}
