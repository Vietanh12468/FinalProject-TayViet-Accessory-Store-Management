import { Component, Input, OnInit, OnChanges, SimpleChanges  } from '@angular/core';

@Component({
  selector: 'app-sub-product-info',
  templateUrl: './sub-product-info.component.html',
  styleUrl: './sub-product-info.component.css'
})
export class SubProductInfoComponent implements OnInit, OnChanges {
  @Input() subProducts: any[] = [
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
    }];
  @Input() mode: string = 'view';

  constructor() { }

  ngOnInit(): void {
  }

  ngOnChanges(changes: SimpleChanges): void {
  }
  invalidAttributes: string[] = [];

  checkValidAttribute(attribute: string) {
    if (this.invalidAttributes.includes(attribute)) {
      return false;
    } else {
      return true;
    }
  }

  handleImg(imgData: any) {
    this.subProducts[imgData.x].listImage[imgData.y] = imgData.img;
  }

  addSubProduct() {
    this.subProducts.push({
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
    });
  }
  addImageSubProduct(x: number) {
    this.subProducts[x].listImage.push('');
  }
}
