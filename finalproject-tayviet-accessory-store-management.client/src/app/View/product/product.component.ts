import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { APIService } from '../../Service/API/api.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ICategory } from '../../Interface/icategory';
import { IProduct } from '../../Interface/iproduct';
import { OutputSearch } from '../../Interface/ioutput-search';
@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrl: './product.component.css'
})
export class ProductComponent implements OnInit, OnChanges {
  constructor(private route: ActivatedRoute, private apiService: APIService) {
  }
  products: IProduct[] = [];
  total: number = 0;
  categorySections: ICategory[] = [];
  ngOnInit() {
    this.apiService.getAllCategories().subscribe((result) => {
      this.categorySections = result.data;
    },
    (error) => {
      console.error(error);
      })
    this.getProductPage();
  }

  ngOnChanges(changes: SimpleChanges){
  }

  getProductPage(page: number = 1) {
    this.apiService.getListObjects('Product', page).subscribe(
      (result) => {
        this.products = [...this.products, ...result.data];
        this.total = result.total;
    },
    (error) => {
      console.error(error);
    })
  }

  searchProductPage(searchInfo: OutputSearch, page: number = 1) {
    this.apiService.searchListObjects('Product', 'name', searchInfo.searchString, page).subscribe(
      (result) => {
        this.products = result.data;
        this.total = result.total;
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
