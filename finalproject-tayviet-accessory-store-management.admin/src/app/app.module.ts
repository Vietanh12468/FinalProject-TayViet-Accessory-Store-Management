import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MessageBoxComponent } from './message-box/message-box.component';
import { AlertBoxComponent } from './alert-box/alert-box.component';
import { TableListComponent } from './table-list/table-list.component';
import { UserInfoBoxComponent } from './user-info-box/user-info-box.component';
import { DetailProductComponent } from './detail-product/detail-product.component';
import { AccountManagerViewComponent } from './account-manager-view/account-manager-view.component';
import { DetailAccountViewComponent } from './detail-account-view/detail-account-view.component';
import { ButtonComponent } from './button/button.component';
import { CategoryTagComponent } from './category-tag/category-tag.component';
import { InfoComponent } from './info/info.component';

@NgModule({
  declarations: [
    AppComponent,
    AlertBoxComponent,
    MessageBoxComponent,
    TableListComponent,
    UserInfoBoxComponent,
    DetailProductComponent,
    AccountManagerViewComponent,
    DetailAccountViewComponent,
    ButtonComponent,
    CategoryTagComponent,
    InfoComponent,
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule, BrowserAnimationsModule, ReactiveFormsModule, FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {

}
