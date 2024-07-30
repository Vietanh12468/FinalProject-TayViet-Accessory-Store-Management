import { Component, OnInit } from '@angular/core';
import { Account } from './Interface/iaccount';
import { AuthenticationService } from './Service/Authentication/authentication.service';
import { APIService } from './Service/API/api.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})

/*export class AppComponent implements OnInit {
  public forecasts: WeatherForecast[] = [];

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getForecasts();
  }

  getForecasts() {
    this.http.get<WeatherForecast[]>('/weatherforecast').subscribe(
      (result) => {
        this.forecasts = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  title = 'finalproject-tayviet-accessory-store-management.client';
}*/

export class AppComponent implements OnInit {
  userInfo: Account | null = null;
  constructor(private apiService: APIService, private authenticationService: AuthenticationService) {}

  ngOnInit() {
    if (this.authenticationService.isLoggedIn() === true) {
      this.getUserInfo();
    }
    this.getCustomers();
  }

  getUserInfo() {
    const token = this.authenticationService.getToken();
    this.apiService.getDetailObject('Customer', token).subscribe(
      (result) => {
        this.userInfo = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }
  getCustomers(page: number = 1) {
    this.apiService.getListObjects('Account', page).subscribe(
      (result) => {
        console.log(result);
      },
      (error) => {
        console.error(error);
      }
    )
  }

  signOut() {
    this.authenticationService.removeToken();
    this.userInfo = null;
    window.location.reload();
  }
  title = 'finalproject-tayviet-accessory-store-management.client';
}
