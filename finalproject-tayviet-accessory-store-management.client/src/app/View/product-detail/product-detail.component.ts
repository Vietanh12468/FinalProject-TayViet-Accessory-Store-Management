import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { APIService } from '../../Service/API/api.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrl: './product-detail.component.css'
})
export class ProductDetailComponent implements OnInit {
  constructor(private route: ActivatedRoute, private apiService: APIService) {
  }
  ngOnInit() {
    this.getDetailProduct();
  }
  getDetailProduct() {
    const id = this.route.snapshot.paramMap.get('id');
    this.apiService.getDetailObject('Product', id).subscribe((data: any) => {
      console.log(data);
    })
  }
}
