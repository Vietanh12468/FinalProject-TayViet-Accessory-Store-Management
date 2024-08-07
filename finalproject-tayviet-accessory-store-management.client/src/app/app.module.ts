import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './View/header/header.component';
import { FooterComponent } from './View/footer/footer.component';
import { MainHomeComponent } from './View/main-home/main-home.component';
import { ProductComponent } from './View/product/product.component';
import { AboutUsComponent } from './View/about-us/about-us.component';
import { ProductDetailComponent } from './View/product-detail/product-detail.component';
import { CartComponent } from './cart/cart.component';
import { ProfileManagerComponent } from './profile-manager/profile-manager.component';
import { PaymentComponent } from './payment/payment.component';
import { VoucherComponent } from './voucher/voucher.component';
import { LoginComponent } from './View/login/login.component';
import { SubProductCarouselComponent } from './Component/sub-product-carousel/sub-product-carousel.component';
import { PagenotFoundComponent } from './pagenot-found/pagenot-found.component';

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
    PagenotFoundComponent
    LoginComponent,
    SubProductCarouselComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule, ReactiveFormsModule, FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
