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
    }
  }
  columns: string[] = []
  readDataAttributesCheck: boolean = false

  readDataAttributes() {
    const sample: any = this.data[0];
    for (const key in sample) {
      if (sample.hasOwnProperty(key)) {
        this.columns.push(key);
        console.log(`${key}: ${sample[key]}`);
      }
    }
    this.readDataAttributesCheck = true
  }

  getMessage(id: number) {
    return `The ID is ${id}`
  }

  // add method view detail with variable id
  viewDetail(id: number) {
    console.log(this.getMessage(id));
  }
}
