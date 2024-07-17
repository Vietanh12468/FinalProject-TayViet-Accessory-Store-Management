import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IAccount } from '../Interface/iaccount';

@Component({
  selector: 'app-account-manager-view',
  templateUrl: './account-manager-view.component.html',
  styleUrl: './account-manager-view.component.css'
})
export class AccountManagerViewComponent implements OnInit {
  public data: any[] = [];
  ngOnInit() {
    this.getAllCustomers();
  }
  constructor(private http: HttpClient) { }

  CustomerList: IAccount[] = [];

  getAllCustomers() {
    this.http.get<any>('/api/Account').subscribe(
      (result) => {
        this.data = result.data;
        console.log(result);
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
