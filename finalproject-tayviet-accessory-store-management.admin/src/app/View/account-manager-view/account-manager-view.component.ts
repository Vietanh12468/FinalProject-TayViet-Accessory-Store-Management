import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IAccount } from '../../Interface/iaccount';

@Component({
  selector: 'app-account-manager-view',
  templateUrl: './account-manager-view.component.html',
  styleUrl: './account-manager-view.component.css'
})
export class AccountManagerViewComponent implements OnInit {
  public data: IAccount[] = [];
  public total: number = 0;

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
}
