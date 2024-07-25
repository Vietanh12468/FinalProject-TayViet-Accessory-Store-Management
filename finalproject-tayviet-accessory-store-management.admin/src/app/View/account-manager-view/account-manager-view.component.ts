import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { IAccount } from '../../Interface/iaccount';
import { SelectOption } from '../../Interface/iselect-option';
import { OutputSearch } from '../../Interface/ioutput-search';
import { TableComponent } from '../../Component/table/table.component';

@Component({
  selector: 'app-account-manager-view',
  templateUrl: './account-manager-view.component.html',
  styleUrl: './account-manager-view.component.css'
})
export class AccountManagerViewComponent implements OnInit {
  @ViewChild('tableComponent') tableComponent!: TableComponent;
  data: IAccount[] = [];
  total: number = 0;
  selectOptions: SelectOption[] = [
    {
      nameOption: 'AccountType',
      options: [
        'admin',
        'customer',
        'employee'
      ]
    },
    {
      nameOption: 'State',
      options: [
        'active',
        'inactive'
      ]
    },
    {
      nameOption: 'OrderBy',
      options: [
        'asc',
        'desc'
      ]
    }
  ]

  ignoredAttributes: string[] = ['password'];
  detailLink = 'account-detail';
  ngOnInit() {
    this.getCustomers();
  }
  constructor(private http: HttpClient) { }

  CustomerList: IAccount[] = [];

  getCustomers(page: number = 1) {
    this.http.get<any>(`/api/Account/page/${page}`).subscribe(
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
    this.http.get<any>(`/api/Account/search/username&&${searchInfo.searchString}&&${0}`).subscribe(
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
