import { Component } from '@angular/core';
import { AuthenticationService } from '../../Service/authentication.service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { IAccount } from '../../Interface/iaccount';

@Component({
  selector: 'app-login-view',
  templateUrl: './login-view.component.html',
  styleUrl: './login-view.component.css'
})
export class LoginViewComponent {
  username: string = '';
  password: string = '';

  constructor(private authenticationService: AuthenticationService, private http: HttpClient, private router: Router) { }

  onSubmit() {
    const loginData: any = { username: this.username, password: this.password };
    this.loginRequest(loginData);
  }

  loginRequest(loginData: any) {
    this.http.post<IAccount>(`/api/Admin/login`, loginData).subscribe(
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
