import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { IOrderHistory } from '../../Interface/iorder-history';
import { SelectOption } from '../../Interface/iselect-option';
import { OutputSearch } from '../../Interface/ioutput-search';
import { TableComponent } from '../../Component/table/table.component';


@Component({
  selector: 'app-order-manager-view',
  templateUrl: './order-manager-view.component.html',
  styleUrl: './order-manager-view.component.css'
})
export class OrderManagerViewComponent implements OnInit {
  @ViewChild('tableComponent') tableComponent!: TableComponent;
  data: IOrderHistory[] = [];
  total: number = 0;
  selectOptions: SelectOption[] = [
    {
      nameOption: 'OrderState',
      options: [
        'Processing',
        'Delivering',
        'Completed'
      ]
    }
  ]
  ignoredAttributes: string[] = [];
  detailLink = 'order-detail';
  ngOnInit() {
    this.getCustomers();
  }
  constructor(private http: HttpClient) { }

  CustomerList: IOrderHistory[] = [];

  getCustomers(page: number = 1) {
    this.http.get<any>(`/api/OrderHistory/page/${page}`).subscribe(
      (result) => {
        this.data = result.data;
        this.total = result.total;
        console.log(result);
      },
      (error) => {
        console.error(error);
      }
    );
  }

  searchSubmit(searchInfo: OutputSearch) {
    this.http.get<any>(`/api/OrderHistory/search/username&&${searchInfo.searchString}&&${0}`).subscribe(
      (result) => {
        this.data = result.data;
        this.total = result.total;
        console.log(result);
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
