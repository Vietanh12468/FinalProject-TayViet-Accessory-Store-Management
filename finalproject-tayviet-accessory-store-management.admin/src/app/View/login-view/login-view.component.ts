import { Component } from '@angular/core';
import { AuthenticationService } from '../../Service/Authentication/authentication.service';
import { Router } from '@angular/router';
import { APIService } from '../../Service/API/api.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-login-view',
  templateUrl: './login-view.component.html',
  styleUrls: ['./login-view.component.css']  
})
export class LoginViewComponent {
  username: string = '';
  password: string = '';

  constructor(
    private authenticationService: AuthenticationService,
    private apiService: APIService,
    private router: Router,
    private snackBar: MatSnackBar  
  ) { }

  onSubmit() {
    const loginData: any = { username: this.username, password: this.password };
    this.apiService.loginRequest(loginData).subscribe(
      (result) => {
        console.log('POST request successful', result);

        this.authenticationService.setToken(result);

        
        this.snackBar.open('Login successful!', 'Close', {
          duration: 3000,
          verticalPosition: 'top',
          horizontalPosition: 'right',
        });

        
        window.location.reload();
      },
      (error) => {
        console.error('Error occurred', error);

        
        this.snackBar.open('Login failed. Please try again.', 'Close', {
          duration: 3000,
          verticalPosition: 'top',
          horizontalPosition: 'right',
        });
      }
    );
  }
}
