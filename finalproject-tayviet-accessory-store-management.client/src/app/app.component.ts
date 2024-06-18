import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {trigger, state, transition, style, animate} from '@angular/animations';

export interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  animations: [
  ]
})
export class AppComponent implements OnInit {
  public forecasts: WeatherForecast[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getForecasts();
  }

  public messageBox = true;
  public focus = true;
  public message = 'message details';

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

  TriggerMessage() {
    this.messageBox = !this.messageBox;
    this.focus = !this.focus;
  }

  close() {
    this.messageBox = !this.messageBox;
    this.focus = !this.focus;
  }

  handleMessage(message: string) {
    this.message = message;
    this.TriggerMessage();
  }
  title = 'finalproject-tayviet-accessory-store-management.client';
}
