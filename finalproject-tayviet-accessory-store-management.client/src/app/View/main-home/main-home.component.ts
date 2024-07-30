import { Component, OnInit, OnChanges, SimpleChanges, AfterViewInit } from '@angular/core';
import { APIService } from '../../Service/API/api.service';
import { IProduct } from '../../Interface/iproduct';

@Component({
  selector: 'app-main-home',
  templateUrl: './main-home.component.html',
  styleUrl: './main-home.component.css'
})
export class MainHomeComponent implements OnInit, OnChanges, AfterViewInit {
  constructor(private api: APIService) { }
  currentSlideIndex = 0;

  latestProducts: IProduct[] = [];

  ngOnChanges(changes: SimpleChanges) {
  }

  ngOnInit() {

    this.api.getLatestProducts().subscribe(
      (result) => {
        this.latestProducts = result;
        console.log(this.latestProducts);
      },
      (error) => {
        console.error('Error occurred', error);
      }
    );
  }

  ngAfterViewInit(): void {
  }

  calculateT(T: number): number {
    let calculatedT = T;
    while (calculatedT >= 6) {
      calculatedT = calculatedT - 6;
    }
    return calculatedT;
  }
}
