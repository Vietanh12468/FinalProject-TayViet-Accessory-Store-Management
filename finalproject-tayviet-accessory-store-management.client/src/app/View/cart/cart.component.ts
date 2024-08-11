import { Component, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import { APIService } from '../../Service/API/api.service';
import { AuthenticationService } from '../../Service/Authentication/authentication.service';
import { ProductInCart, SubProductInCart } from '../../Interface/iorder-history';
import { SubProduct } from '../../Interface/isub-product';

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

  constructor(private apiService: APIService, private authenticationService: AuthenticationService) { }

  ngOnInit() {
    if (this.authenticationService.isLoggedIn() === true) {
      this.getUserCart();

    }
  }

  ngOnChanges(changes: SimpleChanges) {
  }

  getUserCart() {
    const token = this.authenticationService.getToken();
    this.apiService.getDetailObject('Customer', token.userID).subscribe(
      (result) => {
        this.cartList = result.cartList;
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
            name: result.name,
            image: result.image,
            description: result.description,
            subProductList: [],
          }
          for (let subProduct of this.cartList[i].subProductList) {
            const item: SubProduct = result.subProductList.find((item: SubProduct) => item.name === subProduct.subProductName);
            if (!item) {
              throw new Error('Item not found');
            }
            let subProductInCart: SubProductInCart = { subProductName: item.name, cost: item.sellCost, sale: item.discount, quantity: 0 }
            productDisplay.subProductList.push(subProductInCart);
          }
          this.productDisplayList.push(productDisplay);
          console.log(this.productDisplayList);
        },
        (error) => {
          console.error(error);
        }
      );
    }
  }
}

interface CartProductDisplay {
  name: string;
  image: string;
  description: string;
  subProductList: SubProductInCart[]
}
