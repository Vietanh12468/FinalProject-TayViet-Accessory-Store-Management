import { Component, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import { APIService } from '../../Service/API/api.service';
import { AuthenticationService } from '../../Service/Authentication/authentication.service';
import { ProductInCart, SubProductInCart } from '../../Interface/iorder-history';
import { SubProduct } from '../../Interface/isub-product';
import { IOrderHistory } from '../../Interface/iorder-history';

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrl: './history.component.css'
})
export class HistoryComponent implements OnInit, OnChanges {
  orderHistoryList: OrderHistoryDisplay[] = [
    {
      orderID: 'eajiriwajier',
      price: 0,
      state: '',
      lastUpdate: '',
      cartList: [
        {
          productID: 'efqljwiqpew',
          name: 'weqewqewq',
          image: '',
          description: '',
          subProductList: [
            {
              subProductName: 'sdquhwuheuq',
              cost: 0,
              sale: 0,
              quantity: 0
            },
            {
              subProductName: 'weqwjeiwqie',
              cost: 0,
              sale: 0,
              quantity: 0
            }
          ],
          total: 0
        },
        {
          productID: '',
          name: '',
          image: '',
          description: '',
          subProductList: [],
          total: 0
        }
      ]
    }
  ];
  productDisplayList: CartProductDisplay[] = [
    {
      productID: 'efqljwiqpew',
      name: 'weqewqewq',
      image: '',
      description: '',
      subProductList: [
        {
          subProductName: 'sdquhwuheuq',
          cost: 0,
          sale: 0,
          quantity: 0
        },
        {
          subProductName: 'weqwjeiwqie',
          cost: 0,
          sale: 0,
          quantity: 0
        }
      ],
      total: 0
    },
    {
      productID: '',
      name: '',
      image: '',
      description: '',
      subProductList: [],
      total: 0
    }

  ];
  paymentOption = 'PayOnDelivery'
  summary: any = {
    order: 0,
    delivery: 0,
    discount: 0,
    total: 0
  };
  userInfo: any

  constructor(private apiService: APIService, private authenticationService: AuthenticationService) { }

  ngOnInit() {
    if (this.authenticationService.isLoggedIn() === true) {
      this.getUserHistory();
    }
  }

  ngOnChanges(changes: SimpleChanges) {
    for (let productDisplay of this.productDisplayList) {
      this.summary.total += productDisplay.total;
    }
  }

  getUserHistory() {
    const token = this.authenticationService.getToken();
    this.apiService.getDetailObject('Customer', token.userID).subscribe(
      (result) => {
        this.userInfo = result;
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

interface OrderHistoryDisplay {
  orderID: string;
  price: number;
  state: string;
  lastUpdate: string;
  cartList: CartProductDisplay[]
}
