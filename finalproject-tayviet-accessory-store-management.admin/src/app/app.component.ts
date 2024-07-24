import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MessageBoxComponent } from './message-box/message-box.component';
import { MessageBoxCloseComponent } from './message-box-close/message-box-close.component';
import { MessageBoxCancelComponent } from './message-box-cancel/message-box-cancel.component';

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
export class AppComponent implements OnInit {
  @ViewChild(MessageBoxComponent) yesNoBox!: MessageBoxComponent;
  @ViewChild(MessageBoxCloseComponent) closeBox!: MessageBoxCloseComponent;
  @ViewChild(MessageBoxCancelComponent) cancelBox!: MessageBoxCancelComponent;

  public forecasts: WeatherForecast[] = [];
  public orderHistory: OrderHistory[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getForecasts();
    this.getOrderHistory();
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
  getOrderHistory() {
    this.http.get<OrderHistory[]>('/api/orderHistory').subscribe(
      (result) => {
        this.orderHistory = result;
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
  

  openYesNoModal() {
    this.yesNoBox.openModal('Do you want to proceed?');
  }

  onYes() {
    console.log('Yes clicked');
  }

  onNo() {
    console.log('No clicked');
  }

  openCloseModal() {
    this.closeBox.openModal('Action completed!');
  }

  onClose() {
    console.log('Close clicked');
  }

  openCancelModal() {
    this.cancelBox.openModal('Cannot be done!');
  }

  onCancel() {
    console.log('Cancel clicked');
  }
  handleMessage(message: string) {
    this.message = message;
    this.TriggerMessage();
  }
  title = 'finalproject-tayviet-accessory-store-management.client';

}
