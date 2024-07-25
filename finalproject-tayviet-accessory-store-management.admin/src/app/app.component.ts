import { HttpClient } from '@angular/common/http';
import { Component, OnInit, OnChanges } from '@angular/core';
import { AuthenticationService } from './Service/authentication.service';
import { IAccount } from './Interface/iaccount';

export interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
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

  userInfo: any = null;

  constructor(private http: HttpClient, private authenticationService: AuthenticationService) {}

  ngOnInit() {
    if (this.authenticationService.isLoggedIn() === true) {
      this.getUserInfo();
    }
  }

  ngOnChanges() {
  }

  getUserInfo() {
    const token = this.authenticationService.getToken();
    this.http.get<IAccount>(`/api/Admin/${token.userID}`).subscribe(
      (result) => {
        this.userInfo = result;
        console.log(result);
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
