import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccountManagerViewComponent } from './View/account-manager-view/account-manager-view.component';
import { DetailAccountViewComponent } from './View/detail-account-view/detail-account-view.component';
import { DetailProductViewComponent } from './View/detail-product-view/detail-product-view.component';
import { LoginViewComponent } from './View/login-view/login-view.component';

const routes: Routes = [
  { path: 'account-manager', component: AccountManagerViewComponent },
  { path: 'account-manager/:id', component: DetailAccountViewComponent },
  { path: 'product-manager/:id', component: DetailProductViewComponent },
  { path: 'login', component: LoginViewComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
