import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { IOrderHistory } from '../../Interface/iorder-history';
import { SelectOption } from '../../Interface/iselect-option';
import { OutputSearch } from '../../Interface/ioutput-search';
import { TableComponent } from '../../Component/table/table.component';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-order-manager-view',
  templateUrl: './order-manager-view.component.html',
  styleUrls: ['./order-manager-view.component.css']
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
  ];
  ignoredAttributes: string[] = [];
  detailLink = 'order-detail';

  constructor(private http: HttpClient, private snackBar: MatSnackBar) { }

  ngOnInit() {
    this.getCustomers();
  }

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
      },
      (error) => {
        console.error(error);
      }
    );
  }

  // Method to show save successful notification
  showSaveSuccessNotification() {
    this.snackBar.open('Save successful!', 'Close', {
      duration: 3000,
      verticalPosition: 'top',
      horizontalPosition: 'right',
    });
  }
  onSaveClick() {
    this.showSaveSuccessNotification();
  }
}
