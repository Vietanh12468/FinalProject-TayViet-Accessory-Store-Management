import { HttpClientModule } from '@angular/common/http';
import { DatePipe } from '@angular/common'
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatSnackBarModule } from '@angular/material/snack-bar';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AccountManagerViewComponent } from './View/account-manager-view/account-manager-view.component';
import { DetailAccountViewComponent } from './View/detail-account-view/detail-account-view.component';
import { ButtonComponent } from './Component/button/button.component';
import { CategoryTagComponent } from './Component/category-tag/category-tag.component';
import { InfoComponent } from './Component/info/info.component';
import { PaginationComponent } from './Component/pagination/pagination.component';
import { TableComponent } from './Component/table/table.component';
import { DetailProductViewComponent } from './View/detail-product-view/detail-product-view.component';
import { SubProductInfoComponent } from './Component/sub-product-info/sub-product-info.component';
import { SmallImgComponent } from './Component/small-img/small-img.component';
import { LoginViewComponent } from './View/login-view/login-view.component';
import { SearchComponent } from './Component/search/search.component';
import { ProductManagerViewComponent } from './View/product-manager-view/product-manager-view.component';
import { OrderManagerViewComponent } from './View/order-manager-view/order-manager-view.component';
import { CategoryManagerViewComponent } from './View/category-manager-view/category-manager-view.component';
import { MainPageComponent } from './View/main-page/main-page.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { HomePageComponent } from './View/home-page/home-page.component';

@NgModule({
  declarations: [
    AppComponent,
    AccountManagerViewComponent,
    DetailAccountViewComponent,
    ButtonComponent,
    CategoryTagComponent,
    InfoComponent,
    PaginationComponent,
    TableComponent,
    DetailProductViewComponent,
    SubProductInfoComponent,
    SmallImgComponent,
    LoginViewComponent,
    SearchComponent,
    ProductManagerViewComponent,
    OrderManagerViewComponent,
    CategoryManagerViewComponent,
    MainPageComponent,
    HomePageComponent
  ],
  imports: [
    BrowserModule, HttpClientModule, MatSnackBarModule,
    AppRoutingModule, BrowserAnimationsModule, ReactiveFormsModule, FormsModule
  ],
  providers: [
    provideAnimationsAsync(), DatePipe
  ],
  bootstrap: [AppComponent]
})
export class AppModule {

}
