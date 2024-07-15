import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
interface Data {
  id: string;
  customerID: string;
  shipLocation: string;
  cart: Document[];
  history: Document[];
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public forecasts: WeatherForecast[] = [];
  public data: Data[] = [];

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getForecasts();
    this.getData();
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

  getData() {
    this.http.get<Data[]>('/api/data').subscribe(
      (result) => {
        this.data = result;
        console.log(result);
      },
      (error) => {
        console.error(error);
      }
    );
  }

  title = 'finalproject-tayviet-accessory-store-management.client';
}
