import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthenticationService } from './authentication.service';

@Injectable({
  providedIn: 'root'
})
export class UnAuthenticationGuardService implements CanActivate {

  constructor(private authenticationService: AuthenticationService, private router: Router) { }

  canActivate(): boolean {
    if (!this.authenticationService.isLoggedIn()) {
      return true; // User is logged in, allow access
    } else {
      this.router.navigate(['home']); // Redirect to login page if not logged in
      return false;
    }
  }
}
