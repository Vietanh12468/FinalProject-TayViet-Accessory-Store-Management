import { Component, Input, OnChanges, OnInit, SimpleChanges, EventEmitter, Output } from '@angular/core';
import { IProduct } from '../../Interface/iproduct';
import { Router } from '@angular/router';
@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.css'
})
export class ProductListComponent implements OnInit, OnChanges {
  @Output() onShowMore: EventEmitter<any> = new EventEmitter();
  currentPage = 1;
  constructor(private router: Router) { }

  @Input() products: IProduct[] = [];

  navigateToDetail(id: string | undefined) {
    this.router.navigate([`/product-detail/${id}`]);
  }

  ngOnInit(): void {
  }

  ngOnChanges(changes: SimpleChanges): void {
  }

  ShowMoreProduct() {
    this.currentPage++;
    this.onShowMore.emit(this.currentPage);
  }
}
