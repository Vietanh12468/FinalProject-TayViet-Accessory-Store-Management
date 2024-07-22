import { Component, EventEmitter, Output} from '@angular/core';

@Component({
  selector: 'app-table-list',
  templateUrl: './table-list.component.html',
  styleUrl: './table-list.component.css'
})
export class TableListComponent {
  @Output() message = new EventEmitter();
  data: any[] = [
    { id: 1, name: 'John Doe', age: 25 },
    { id: 2, name: 'Jane Smith', age: 30 },
    { id: 3, name: 'Bob Johnson', age: 28 },
    { id: 4, name: 'Bob Johnson', age: 38 },
  // Add more rows as needed
  ]
  columns = ['id', 'name', 'age']

  getMessage(id: number) {
    return `The ID is ${id}`
  }

  // add method view detail with variable id
  viewDetail(id: number) {
    console.log(this.getMessage(id));
    this.message.emit(this.getMessage(id))
  }
}
