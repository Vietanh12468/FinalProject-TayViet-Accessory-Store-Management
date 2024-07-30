import { APIService } from './Service/API/api.service';
import { Component, OnInit, OnChanges } from '@angular/core';
import { AuthenticationService } from './Service/Authentication/authentication.service';
import { Account } from './Interface/iaccount';

export interface OrderHistory {
  id: string;
  customerID: string;
  shipLocation: string;
  cart: Document[];
  history: Document[];
}
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  animations: [
  ]
})
export class AppComponent implements OnInit, OnChanges {

  userInfo: Account | null = null;

  constructor(private apiService: APIService, private authenticationService: AuthenticationService) {}

  ngOnInit() {
    if (this.authenticationService.isLoggedIn() === true) {
      this.getUserInfo();
    }
  }

  ngOnChanges() {
  }

  getUserInfo() {
    const token = this.authenticationService.getToken();
    this.apiService.getDetailObject('Admin', token).subscribe(
      (result) => {
        this.userInfo = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  title = 'finalproject-tayviet-accessory-store-management.client';

  signOut() {
    this.authenticationService.removeToken();
    this.userInfo = null;
    window.location.reload();
  }
}
