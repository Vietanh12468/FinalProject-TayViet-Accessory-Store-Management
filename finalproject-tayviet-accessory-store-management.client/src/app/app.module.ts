import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatSnackBarModule } from '@angular/material/snack-bar';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './View/header/header.component';
import { FooterComponent } from './View/footer/footer.component';
import { MainHomeComponent } from './View/main-home/main-home.component';
import { ProductComponent } from './View/product/product.component';
import { AboutUsComponent } from './View/about-us/about-us.component';
import { ProductDetailComponent } from './View/product-detail/product-detail.component';
import { CartComponent } from './View/cart/cart.component';
import { ProfileManagerComponent } from './View/profile-manager/profile-manager.component';
import { PaymentComponent } from './payment/payment.component';
import { VoucherComponent } from './voucher/voucher.component';
import { LoginComponent } from './View/login/login.component';
import { SubProductCarouselComponent } from './Component/sub-product-carousel/sub-product-carousel.component';
import { PagenotFoundComponent } from './pagenot-found/pagenot-found.component';
import { SmallImgComponent } from './Component/small-img/small-img.component';
import { CategoryOptionComponent } from './Component/category-option/category-option.component';
import { SearchBarComponent } from './Component/search-bar/search-bar.component';
import { ProductListComponent } from './Component/product-list/product-list.component';
import { HistoryComponent } from './View/history/history.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { OrderHistoryComponent } from './Component/order-history/order-history.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    MainHomeComponent,
    ProductComponent,
    AboutUsComponent,
    ProductDetailComponent,
    CartComponent,
    ProfileManagerComponent,
    PaymentComponent,
    VoucherComponent,
    LoginComponent,
    PagenotFoundComponent,
    LoginComponent,
    SubProductCarouselComponent,
    SmallImgComponent,
    CategoryOptionComponent,
    SearchBarComponent,
    ProductListComponent,
    HistoryComponent,
    OrderHistoryComponent
  ],
  imports: [
    BrowserModule, HttpClientModule, MatSnackBarModule,
    AppRoutingModule, ReactiveFormsModule, FormsModule
  ],
  providers: [
    provideAnimationsAsync()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
