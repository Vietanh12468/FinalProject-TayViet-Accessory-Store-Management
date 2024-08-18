import { Component, Input } from '@angular/core';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-order-history',
  templateUrl: './order-history.component.html',
  styleUrl: './order-history.component.css'
})
export class OrderHistoryComponent {
  @Input() orderHistoryList: any;
  constructor(private datePipe: DatePipe) { }

  formatDate(date: Date): string | null {
    return this.datePipe.transform(date, 'dd-MM-yyyy');
  }
}
