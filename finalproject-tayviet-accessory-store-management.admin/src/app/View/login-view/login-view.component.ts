import { Component } from '@angular/core';

@Component({
  selector: 'app-login-view',
  templateUrl: './login-view.component.html',
  styleUrl: './login-view.component.css'
})
export class LoginViewComponent {
  email: string = '';
  password: string = '';

  constructor() { }

  onSubmit() {
    console.log('Email:', this.email);
    console.log('Password:', this.password);
    // Add your authentication logic here
  }
}
