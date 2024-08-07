import { HttpClient } from '@angular/common/http';
import { Component, OnInit, OnChanges, ViewChild } from '@angular/core';
import { AuthenticationService } from './Service/Authentication/authentication.service';
import { APIService } from './Service/API/api.service';
import { IAccount } from './Interface/iaccount';
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
export class AppComponent implements OnInit, OnChanges {
  @ViewChild(MessageBoxComponent) yesNoBox!: MessageBoxComponent;
  @ViewChild(MessageBoxCloseComponent) closeBox!: MessageBoxCloseComponent;
  @ViewChild(MessageBoxCancelComponent) cancelBox!: MessageBoxCancelComponent;
  userInfo: any = null;
  public messageBox = true;
  public focus = true;
  public message = 'message details';
  constructor(private http: HttpClient, private authenticationService: AuthenticationService, private apiService: APIService) {
  }

  activeItemIndex: number = 0;
  sidebarItems = [
    { label: 'Home', icon: '#home', link: 'home' },
    { label: 'Dashboard', icon: '#speedometer2',  },
    { label: 'Orders', icon: '#table', link: 'order-manager' },
    { label: 'Products', icon: '#grid', link: 'product-manager' },
    { label: 'Customers', icon: '#people-circle', link: 'account-manager' },
    { label: 'Category', icon: '#home', link: 'category-manager' },
    { label: 'Settings', icon: '#home' }
  ];

  setActiveItem(index: number) {
    this.activeItemIndex = index;
  }

  ngOnInit() {
    if (this.authenticationService.isLoggedIn() === true) {
      this.getUserInfo();
    }
/*    this.authenticationService.removeToken();*/
  }

  ngOnChanges() {
  }

  getUserInfo() {
    const token = this.authenticationService.getToken();
    this.apiService.getDetailObject('Admin', token.userID).subscribe(
      (result) => {
        this.userInfo = result;
      },
      (error) => {
        console.error(error);
      }
    );
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

  signOut() {
    this.authenticationService.removeToken();
    this.userInfo = null;
    window.location.reload();
  }

  TriggerMessage() {
    this.messageBox = !this.messageBox;
    this.focus = !this.focus;
  }

  close() {
    this.messageBox = !this.messageBox;
    this.focus = !this.focus;
  }
}
