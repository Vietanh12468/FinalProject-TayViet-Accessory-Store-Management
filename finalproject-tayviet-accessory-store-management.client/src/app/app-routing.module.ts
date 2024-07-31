import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './View/login/login.component';
import { MainHomeComponent } from './View/main-home/main-home.component';
import { AboutUsComponent } from './View/about-us/about-us.component';
import { ProductComponent } from './View/product/product.component';
import { ProductDetailComponent } from './View/product-detail/product-detail.component';


import { AuthenticationGuardService } from './Service/Authentication/authentication-guard.service';
import { UnAuthenticationGuardService } from './Service/Authentication/un-authentication-guard.service';

const routes: Routes = [
  { path: 'home', component: MainHomeComponent },
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'login', component: LoginComponent, canActivate: [UnAuthenticationGuardService] },
  { path: 'about-us', component: AboutUsComponent },
  { path: 'product-detail/:id', component: ProductDetailComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
