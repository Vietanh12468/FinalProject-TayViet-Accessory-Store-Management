import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})

export class LoginComponent {
  username: string = '';
  password: string = '';
  error: string = '';
  constructor(private http: HttpClient, private router: Router) { }

  login() {
    this.http.post<{ token: string }>('/api/login', { username: this.username, password: this.password })
      .subscribe(
        (response) => {
          localStorage.setItem('token', response.token);
          this.router.navigate(['/dashboard']);
        },
        (error) => {
          this.error = error.error.error;
        }
      );
  }
}
