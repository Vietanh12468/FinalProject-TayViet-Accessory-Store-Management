import { Component, OnInit, OnChanges, SimpleChanges} from '@angular/core';
import { APIService } from '../../Service/API/api.service';
import { IProduct } from '../../Interface/iproduct';
import { Router } from '@angular/router';

@Component({
  selector: 'app-main-home',
  templateUrl: './main-home.component.html',
  styleUrl: './main-home.component.css'
})
export class MainHomeComponent implements OnInit, OnChanges {
  constructor(private api: APIService, private router: Router) { }
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
    while (calculatedT >= 6) {
      calculatedT = calculatedT - 6;
    }
    return calculatedT;
  }

  navigateToDetail(id: string|undefined) {
    this.router.navigate([`/product-detail/${id}`]);
  }
}
