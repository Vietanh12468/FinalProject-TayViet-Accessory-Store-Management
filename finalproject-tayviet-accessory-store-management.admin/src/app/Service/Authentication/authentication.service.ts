import { Injectable } from '@angular/core';
import { IAccount } from '../../Interface/iaccount';
@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private token = 'token';

  constructor() { }

  setToken(user: IAccount): void {
    localStorage.setItem(this.token, user.id);
  }

  getToken(): any | null {
    if (localStorage.getItem(this.token) === null) {
      return null;
    }
    return { userID: localStorage.getItem(this.token) }
  }

  removeToken(): void {
    localStorage.removeItem(this.token);
  }

  isLoggedIn(): boolean {
    if (localStorage.getItem(this.token) === null) {
      return false;
    }
    return true;
  }

}
