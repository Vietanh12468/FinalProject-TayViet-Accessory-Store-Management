import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MessageBoxComponent } from './message-box/message-box.component';
import { AlertBoxComponent } from './alert-box/alert-box.component';
import { TableListComponent } from './table-list/table-list.component';
import { UserInfoBoxComponent } from './user-info-box/user-info-box.component';
import { DetailProductComponent } from './detail-product/detail-product.component';
import { AdminLoginComponent } from './admin-login/admin-login.component';
import { MessageBoxCloseComponent } from './message-box-close/message-box-close.component';
import { MessageBoxCancelComponent } from './message-box-cancel/message-box-cancel.component';
import { MainPageComponent } from './main-page/main-page.component';

@NgModule({
  declarations: [
    AppComponent,
    AlertBoxComponent,
    MessageBoxComponent,
    TableListComponent,
    UserInfoBoxComponent,
    DetailProductComponent,
    AdminLoginComponent,
    MessageBoxCloseComponent,
    MessageBoxCancelComponent,
    MainPageComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule, BrowserAnimationsModule, FormsModule 
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
