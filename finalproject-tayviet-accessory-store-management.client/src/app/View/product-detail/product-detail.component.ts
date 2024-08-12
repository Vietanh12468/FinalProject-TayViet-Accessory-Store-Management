import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { APIService } from '../../Service/API/api.service';
import { AuthenticationService } from '../../Service/Authentication/authentication.service';
import { Product } from '../../Interface/iproduct';
import { SubProduct } from '../../Interface/isub-product';
import { MatSnackBar } from '@angular/material/snack-bar';

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
  constructor(private route: ActivatedRoute, private apiService: APIService, private authenticationService: AuthenticationService, private snackBar: MatSnackBar) {
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

  addToCart() {
    const token = this.authenticationService.getToken();
    this.apiService.addToCart(token.userID, this.product.id, this.currentSubProduct.name, this.numberAdd).subscribe(
      (result) => {
        console.log("Add to cart successfully");
        this.snackBar.open('Add to cart successfully', 'Close', {
          duration: 10000,
          verticalPosition: 'top',
          horizontalPosition: 'right',
        });
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
