import { Component } from '@angular/core';
import { AuthenticationService } from '../../Service/Authentication/authentication.service';
import { Router } from '@angular/router';
import {APIService} from '../../Service/API/api.service';

@Component({
  selector: 'app-login-view',
  templateUrl: './login-view.component.html',
  styleUrl: './login-view.component.css'
})
export class LoginViewComponent {
  username: string = '';
  password: string = '';

  constructor(private authenticationService: AuthenticationService, private apiService: APIService, private router: Router) { }

  onSubmit() {
    const loginData: any = { username: this.username, password: this.password };
    this.apiService.loginRequest(loginData).subscribe(
      (result) => {
        console.log('POST request successful', result);
        this.authenticationService.setToken(result);
        window.location.reload();
      },
      (error) => {
        console.error('Error occurred', error);
      }
    );
  }
}
