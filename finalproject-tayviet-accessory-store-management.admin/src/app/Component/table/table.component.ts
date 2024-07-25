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
}
