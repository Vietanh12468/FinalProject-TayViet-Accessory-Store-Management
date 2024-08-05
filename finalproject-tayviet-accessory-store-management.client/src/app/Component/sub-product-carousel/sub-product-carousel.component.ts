import { Component, Input, NgIterable, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import { SubProduct } from '../../Interface/isub-product';

@Component({
  selector: 'app-sub-product-carousel',
  templateUrl: './sub-product-carousel.component.html',
  styleUrl: './sub-product-carousel.component.css'
})
export class SubProductCarouselComponent implements OnInit, OnChanges {
  @Input() subProduct: any;
  imgs: (string | ArrayBuffer | null)[] = [];

  constructor() {

  }

  ngOnChanges(changes: SimpleChanges): void {
    this.imgs = this.subProduct.listImage;
  }

  ngOnInit(): void {
  }

  CurrentTriggered = 0;

  ChangeCurrentTriggered(x: number) {
    console.log(x);
  }
}
