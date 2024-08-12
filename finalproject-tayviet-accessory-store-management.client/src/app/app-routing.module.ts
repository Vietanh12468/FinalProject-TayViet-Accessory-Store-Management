import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './View/login/login.component';
import { MainHomeComponent } from './View/main-home/main-home.component';
import { AboutUsComponent } from './View/about-us/about-us.component';
import { ProductComponent } from './View/product/product.component';
import { ProductDetailComponent } from './View/product-detail/product-detail.component';
import { PagenotFoundComponent } from './pagenot-found/pagenot-found.component';
import { CartComponent } from './View/cart/cart.component';
import { ProfileManagerComponent } from './View/profile-manager/profile-manager.component';
import { HistoryComponent } from './View/history/history.component';


import { AuthenticationGuardService } from './Service/Authentication/authentication-guard.service';
import { UnAuthenticationGuardService } from './Service/Authentication/un-authentication-guard.service';

const routes: Routes = [
  { path: 'home', component: MainHomeComponent },
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'login', component: LoginComponent, canActivate: [UnAuthenticationGuardService] },
  { path: 'about-us', component: AboutUsComponent },
  { path: 'product', component: ProductComponent },
  { path: 'product-detail/:id', component: ProductDetailComponent },
  { path: 'pagenotfound', component: PagenotFoundComponent },
  { path: 'cart', component: CartComponent, canActivate: [AuthenticationGuardService] },
  { path: 'profile', component: ProfileManagerComponent, canActivate: [AuthenticationGuardService] },
  { path: 'history', component: HistoryComponent},
  { path: '**', redirectTo: '/pagenotfound', },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
