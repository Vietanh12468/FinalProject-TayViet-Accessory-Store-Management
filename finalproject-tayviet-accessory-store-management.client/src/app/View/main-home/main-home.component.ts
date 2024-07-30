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
    console.log(this.latestProducts);

    let items = document.querySelectorAll('.carousel .carousel-item') as NodeListOf<HTMLElement>;

    items.forEach((el: HTMLElement) => {
      const minPerSlide: number = 4;
      let next: HTMLElement | null = el.nextElementSibling as HTMLElement | null;

      for (let i = 1; i < minPerSlide; i++) {
        if (!next) {
          // wrap carousel by using first child
          next = items[0];
        }

        let cloneChild = next.cloneNode(true) as HTMLElement;
        el.appendChild(cloneChild.children[0]);
        next = next.nextElementSibling as HTMLElement | null;
      }
    });
  }

  ngAfterViewInit(): void {
  }
}
