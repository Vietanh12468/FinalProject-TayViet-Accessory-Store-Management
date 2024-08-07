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
  loginData: any = {
    username: '',
    password: ''
  };

  registerData: any = {
    "name": "",
    "email": "",
    "password": "",
    "phoneNumber": "",
    "username": ""
  }

  repassword: string = '';
  constructor(private authenticationService: AuthenticationService, private apiService: APIService, private router: Router) { }

  onLogin() {
    console.log(this.loginData);  
    this.apiService.loginRequest(this.loginData).subscribe(
      (result) => {
        console.log('POST request successful', result);
        alert('login successful');
        this.authenticationService.setToken(result);
        window.location.reload();
      },
      (error) => {
        console.error('Error occurred', error);
      }
    );
  }
  onSignUp() {
    if (this.registerData.password !== this.repassword) {
      alert('Password does not match');
      return;
    }
    if (this.registerData.name === '' || this.registerData.email === '' || this.registerData.password === '' || this.registerData.phoneNumber === '' || this.registerData.username === '') {
      alert('Please fill in all fields');
      return;
    }
    this.apiService.createDetailObject('Customer', this.registerData).subscribe(
      (result) => {
        console.log('POST request successful', result);
        alert('register successful');
        window.location.reload();
      },
      (error) => {
        console.error('Error occurred', error);
      }
    );
  }
}
