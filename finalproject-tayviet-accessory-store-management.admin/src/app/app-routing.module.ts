import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccountManagerViewComponent } from './View/account-manager-view/account-manager-view.component';
import { DetailAccountViewComponent } from './View/detail-account-view/detail-account-view.component';
import { DetailProductViewComponent } from './View/detail-product-view/detail-product-view.component';
import { LoginViewComponent } from './View/login-view/login-view.component';
import { ProductManagerViewComponent } from './View/product-manager-view/product-manager-view.component';
import { OrderManagerViewComponent } from './View/order-manager-view/order-manager-view.component';
import { CategoryManagerViewComponent } from './View/category-manager-view/category-manager-view.component';
import { MainPageComponent } from './View/main-page/main-page.component';
import { HomePageComponent } from './View/home-page/home-page.component'

import { AuthenticationGuardService } from './Service/Authentication/authentication-guard.service';
import { UnAuthenticationGuardService } from './Service/Authentication/un-authentication-guard.service';
const routes: Routes = [
  { path: '', component: MainPageComponent, canActivate: [UnAuthenticationGuardService] },
  { path: 'home', component: HomePageComponent, canActivate: [AuthenticationGuardService] },
  { path: 'account-manager', component: AccountManagerViewComponent, canActivate: [AuthenticationGuardService] },
  { path: 'account-manager/create', component: DetailAccountViewComponent, canActivate: [AuthenticationGuardService], data: { some_data: 'some value' } },
  { path: 'account-detail/:id', component: DetailAccountViewComponent, canActivate: [AuthenticationGuardService], }, 
  { path: 'product-manager', component: ProductManagerViewComponent, canActivate: [AuthenticationGuardService] },
  { path: 'product-manager/create', component: DetailProductViewComponent, canActivate: [AuthenticationGuardService] },
  { path: 'product-detail/:id', component: DetailProductViewComponent, canActivate: [AuthenticationGuardService], },
  { path: 'order-manager', component: OrderManagerViewComponent, canActivate: [AuthenticationGuardService], },
  { path: 'category-manager', component: CategoryManagerViewComponent, canActivate: [AuthenticationGuardService], },
  { path: 'login', component: LoginViewComponent, canActivate: [UnAuthenticationGuardService] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
