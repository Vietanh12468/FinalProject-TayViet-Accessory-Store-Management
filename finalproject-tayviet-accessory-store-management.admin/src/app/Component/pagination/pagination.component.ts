import { Component, Input, OnInit, OnChanges, Output, EventEmitter, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
  styleUrl: './pagination.component.css'
})
export class PaginationComponent implements OnInit, OnChanges {
  @Input() total: number = 0;
  @Output() onPageChange = new EventEmitter<number>();

  currentPage: number = 1;
  pageOptions: string[] = [];
  ngOnInit(): void {
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.calculateTotalPages();
    this.calculatePageOptions();
  }

  totalPages: number = 0;

  calculateTotalPages() {
    this.totalPages = Math.ceil(this.total / 20);
    console.log(this.totalPages);
  }

  calculatePageOptions() {
    this.pageOptions = [];
    for (let i = 1; i <= this.totalPages; i++) {
      this.pageOptions.push(i.toString());
    }
  }

  selectPage(page: string) {
    this.currentPage = parseInt(page);
    this.onPageChange.emit(this.currentPage);
    console.log(this.currentPage);
  }
}
