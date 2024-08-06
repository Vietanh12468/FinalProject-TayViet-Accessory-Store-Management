import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { APIService } from '../../Service/API/api.service';
import { Product } from '../../Interface/iproduct';
import { SubProduct } from '../../Interface/isub-product';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrl: './product-detail.component.css'
})
export class ProductDetailComponent implements OnInit {
  product: Product = new Product();
  currentSubProduct: SubProduct = new SubProduct();
  mode: string = 'general-info';
  numberAdd = 1;
  constructor(private route: ActivatedRoute, private apiService: APIService) {
  }
  ngOnInit() {
    this.getDetailProduct();
  }
  getDetailProduct() {
    const id = this.route.snapshot.paramMap.get('id');
    this.apiService.getDetailObject('Product', id).subscribe((data: Product) => {
      this.product = data;
      this.currentSubProduct = data.subProductList[0];
    })
  }
  changeCurrentSubProduct(x: number) {
    this.currentSubProduct = this.product.subProductList[x];
  }

  changeMode(mode: string) {
    this.mode = mode;
  }

  changeNumberAdd(number: number) {
    this.numberAdd += number;
    if (this.numberAdd < 1) {
      this.numberAdd = 1;
    }
  }
}
