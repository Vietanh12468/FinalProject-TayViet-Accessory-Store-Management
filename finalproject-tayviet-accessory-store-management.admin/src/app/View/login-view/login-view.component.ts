import { Component } from '@angular/core';
import { AuthenticationService } from '../../Service/authentication.service';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-login-view',
  templateUrl: './login-view.component.html',
  styleUrl: './login-view.component.css'
})
export class LoginViewComponent {
  username: string = '';
  password: string = '';

  constructor(private authenticationService: AuthenticationService, private http: HttpClient) { }

  onSubmit() {
    const loginData: any = { username: this.username, password: this.password };
    this.loginRequest(loginData);
  }

  loginRequest(loginData: any) {
    this.http.post(`/api/Admin/login`, loginData).subscribe(
      (response) => {
        console.log('POST request successful', response);
        this.authenticationService.setToken(this.username, this.password);
        console.log('Token:', this.authenticationService.getToken());
      },
      (error) => {
        console.error('Error occurred', error);
      }
    );
  }
}
