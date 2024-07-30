import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './View/login/login.component';


import { AuthenticationGuardService } from './Service/Authentication/authentication-guard.service';
import { UnAuthenticationGuardService } from './Service/Authentication/un-authentication-guard.service';

const routes: Routes = [

  { path: 'login', component: LoginComponent, canActivate: [UnAuthenticationGuardService] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
