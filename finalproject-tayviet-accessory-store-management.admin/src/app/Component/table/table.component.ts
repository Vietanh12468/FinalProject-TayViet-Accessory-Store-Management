import { Component, EventEmitter, Input, OnChanges, SimpleChanges, Output, OnInit } from '@angular/core';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrl: './table.component.css'
})
export class TableComponent implements OnChanges, OnInit {
  @Input() data: any[] = [
    { id: 1, name: 'John Doe', age: 25 },
  ]
  @Input() ignoredAttributes: string[] = [];
  @Input() detailLink: string = '';
  @Input() mode = 'view';
  @Input() orderDisplay: any[] = [];
  @Output() addCategoryHandler: EventEmitter<any> = new EventEmitter();
  @Output() deleteCategoryHandler: EventEmitter<any> = new EventEmitter();
  @Output() deleteCategorySectionHandler: EventEmitter<any> = new EventEmitter();
  @Output() changeCategoryHandler: EventEmitter<any> = new EventEmitter();
  @Output() categoryNameHandler: EventEmitter<any> = new EventEmitter();
  @Output() newOrderStateHandler: EventEmitter<any> = new EventEmitter();

  ngOnInit(): void {
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.readDataAttributes();
    this.renderImage();
  }
  columns: string[] = []

  readDataAttributes() {
    const sample: any = this.data[0];
    for (const key in sample) {
      if (sample.hasOwnProperty(key) && !this.columns.includes(key)) {
        this.columns.push(key);
      }
    }
  }

  renderImage() {
    for (let index = 0; index < this.data.length; index++) {
      const reader = new FileReader();
      reader.onload = () => {
        this.data[index].image = reader.result;
      };
    }
  }

  getMessage(id: number) {
    return `The ID is ${id}`
  }

  // add method view detail with variable id
  viewDetail(id: number) {
    console.log(this.getMessage(id));
  }

  addCategory(x: number) {
    this.addCategoryHandler.emit(x);
  }

  handleCategoryDelete(x: number, y: number) {
    this.deleteCategoryHandler.emit({ x, y });
  }

  deleteCategorySection(x: number) {
    this.deleteCategorySectionHandler.emit(x);
  }

  handleCategoryChange(x: number, categoryInfo: any) {
    categoryInfo['x'] = x
    this.changeCategoryHandler.emit(categoryInfo);
  }

  changeCategorySectionName(x: number) {
    this.categoryNameHandler.emit({ nameSection: this.data[x].name, x });
  }

  newOrderState(index: number, event: any) {
    const orderState = event.target.value;
    this.newOrderStateHandler.emit({ index, orderState });
  }

  orderStateOptions = ['Ordered', 'Processing', 'OutForDelivery', 'Delivered', 'CompletePayment', 'CompleteOrder', 'Cancelled', 'Refunded'];
}
