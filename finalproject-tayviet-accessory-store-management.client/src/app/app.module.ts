import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { MainHomeComponent } from './main-home/main-home.component';
import { ProductComponent } from './product/product.component';
import { AboutUsComponent } from './about-us/about-us.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { CartComponent } from './cart/cart.component';
import { ProfileManagerComponent } from './profile-manager/profile-manager.component';
import { PaymentComponent } from './payment/payment.component';
import { VoucherComponent } from './voucher/voucher.component';
import { LoginComponent } from './login/login.component';

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
    LoginComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
