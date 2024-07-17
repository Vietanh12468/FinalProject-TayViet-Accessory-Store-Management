import { Component, EventEmitter, Input, OnChanges, SimpleChanges, Output, OnInit } from '@angular/core';

@Component({
  selector: 'app-table-list',
  templateUrl: './table-list.component.html',
  styleUrl: './table-list.component.css'
})
export class TableListComponent implements OnChanges, OnInit {
  @Input() data: any[] = [
    { id: 1, name: 'John Doe', age: 25 },
  ]

  ngOnInit(): void {
    this.readDataAttributesCheck = false
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (!this.readDataAttributesCheck) {
      this.readDataAttributes();
      this.renderImage();
    }
  }
  columns: string[] = []
  readDataAttributesCheck: boolean = false

  readDataAttributes() {
    const sample: any = this.data[0];
    for (const key in sample) {
      if (sample.hasOwnProperty(key)) {
        this.columns.push(key);
      }
    }
    this.readDataAttributesCheck = true
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
