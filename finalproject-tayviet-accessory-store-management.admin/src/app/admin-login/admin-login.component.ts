import { Component } from '@angular/core';

@Component({
  selector: 'app-admin-login',
  templateUrl: './admin-login.component.html',
  styleUrl: './admin-login.component.css'
})
export class AdminLoginComponent {
  email: string = '';
  password: string = '';

  constructor() { }

  onSubmit() {
    console.log('Email:', this.email);
    console.log('Password:', this.password);
    // Add your authentication logic here
  }
}

