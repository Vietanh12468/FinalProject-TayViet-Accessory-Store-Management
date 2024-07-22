import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MessageBoxComponent } from './message-box/message-box.component';
import { AlertBoxComponent } from './alert-box/alert-box.component';
import { UserInfoBoxComponent } from './user-info-box/user-info-box.component';
import { DetailProductComponent } from './detail-product/detail-product.component';
import { AccountManagerViewComponent } from './View/account-manager-view/account-manager-view.component';
import { DetailAccountViewComponent } from './View/detail-account-view/detail-account-view.component';
import { ButtonComponent } from './Component/button/button.component';
import { CategoryTagComponent } from './Component/category-tag/category-tag.component';
import { InfoComponent } from './Component/info/info.component';
import { PaginationComponent } from './Component/pagination/pagination.component';
import { TableComponent } from './Component/table/table.component';
import { DetailProductViewComponent } from './View/detail-product-view/detail-product-view.component';
import { SubProductInfoComponent } from './Component/sub-product-info/sub-product-info.component';
import { AdminLoginComponent } from './admin-login/admin-login.component';

@NgModule({
  declarations: [
    AppComponent,
    AlertBoxComponent,
    MessageBoxComponent,
    UserInfoBoxComponent,
    DetailProductComponent,
    AccountManagerViewComponent,
    DetailAccountViewComponent,
    ButtonComponent,
    CategoryTagComponent,
    InfoComponent,
    PaginationComponent,
    TableComponent,
    DetailProductViewComponent,
    SubProductInfoComponent,
    DetailProductComponent,
    AdminLoginComponent
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
