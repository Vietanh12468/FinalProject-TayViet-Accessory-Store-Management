import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from '../../Service/Authentication/authentication.service';
import { APIService } from '../../Service/API/api.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})

export class LoginComponent {
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
