import { Component, OnInit, OnChanges, SimpleChanges} from '@angular/core';
import { APIService } from '../../Service/API/api.service';
import { IProduct } from '../../Interface/iproduct';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-main-home',
  templateUrl: './main-home.component.html',
  styleUrl: './main-home.component.css'
})
export class MainHomeComponent implements OnInit, OnChanges {
  constructor(private api: APIService, private router: Router, private snackBar: MatSnackBar) { }
  currentSlideIndex = 0;

  latestProducts: IProduct[] = [];

  ngOnChanges(changes: SimpleChanges) {
  }

  ngOnInit() {

    this.api.getLatestProducts().subscribe(
      (result) => {
        this.latestProducts = result;
      },
      (error) => {
        console.error('Error occurred', error);
      }
    );
  }


  calculateT(T: number): number {
    let calculatedT = T;
    if (calculatedT >= this.latestProducts.length) {
      calculatedT = calculatedT - this.latestProducts.length;
    }
    return calculatedT;
  }

  navigateToDetail(id: string|undefined) {
    this.router.navigate([`/product-detail/${id}`]);
  }
}
