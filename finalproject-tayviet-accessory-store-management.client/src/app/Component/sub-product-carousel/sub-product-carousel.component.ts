import { Component } from '@angular/core';

@Component({
  selector: 'app-sub-product-carousel',
  templateUrl: './sub-product-carousel.component.html',
  styleUrl: './sub-product-carousel.component.css'
})
export class SubProductCarouselComponent {
  imgs: string[] = ['assets/image/COD.jpg', 'assets/image/Back.jpg', 'assets/image/Wallet.jpg', 'assets/image/COD.jpg', 'assets/image/Back.jpg'];

  CurrentTriggered = 0;

  ChangeCurrentTriggered(x: number) {
    console.log(x);
  }
}
