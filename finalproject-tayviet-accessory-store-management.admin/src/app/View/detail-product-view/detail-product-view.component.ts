import { Component, Input, SimpleChanges, OnInit, ViewChild, ElementRef } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IProduct } from '../../Interface/iproduct';
import { InfoComponent } from '../../Component/info/info.component';
@Component({
  selector: 'app-detail-product-view',
  templateUrl: './detail-product-view.component.html',
  styleUrl: './detail-product-view.component.css'
})
export class DetailProductViewComponent implements OnInit {
  @Input() id: string = '';
  @Input() mode: string = 'view';
  @ViewChild('infoComponent') infoComponent!: InfoComponent;

  product: any = {
    "id": "668733aab060c690227b3878",
    "name": "string",
    "description": "string",
    "image": "string",
    "categoryList": [
      "string"
    ],
    "subProductList": [
      {
        "name": "string",
        "description": "string",
        "listImage": [
          "string"
        ],
        "inStock": 0,
        "state": 'null',
        "buyCost": 0,
        "sellCost": 0,
        "discount": 0
      },
      {
        "name": "string",
        "description": "string",
        "listImage": [
          "string"
        ],
        "inStock": 0,
        "state": 'null',
        "buyCost": 0,
        "sellCost": 0,
        "discount": 0
      },
      {
        "name": "string",
        "description": "string",
        "listImage": [
          "string"
        ],
        "inStock": 0,
        "state": null,
        "buyCost": 0,
        "sellCost": 0,
        "discount": 0
      }
    ],
    "brandID": "string"
  };

  ngOnInit() {
    if (this.mode === 'create') {
      for (const key in this.product) {
        this.product[key] = null;
      }
      console.log(this.product);
    }
    else {
      this.getDetailProduct();
    }
  }

  constructor(private http: HttpClient) { }
  getDetailProduct() {
    this.http.get<IProduct>(`/api/Product/${this.id}`).subscribe(
      (result) => {
        this.product = result;
        console.log(result);
      },
      (error) => {
        console.error(error);
      }
    );
  }

  handleData(data: any) {
    // Handle the emitted event data here
    this.product = data;
  }

  onSubmit() {
    if (this.mode === 'view') {
      return;
    }
    this.infoComponent.getInfo();
    // Check If Valid account
    const invalidAttribute: string[] = [];
    for (const key in this.product) {
      if ((this.product[key] === null || this.product[key] === '') && key !== 'id' && key !== 'image') {
        invalidAttribute.push(key);
      }
    }
    if (invalidAttribute.length > 0) {
      this.infoComponent.handleInvalidAttributes(invalidAttribute)
      return
    }
    if (this.mode === 'change') {
      this.http.put('/api/Product', this.product).subscribe(
        response => {
          console.log('PUT request successful', response);
        },
        error => {
          console.error('Error occurred', error);
        }
      );
    }
    else if (this.mode === 'create') {
      this.http.post('/api/Product', this.product).subscribe(
        response => {
          console.log('POST request successful', response);
        },
        error => {
          console.error('Error occurred', error);
        }
      );
    }
    this.mode = 'view';
  }

  onEditUserClick() {
    this.mode = 'change';
  }

  onBackClick() {
    this.mode = 'view';
    this.getDetailProduct();
  }

}
