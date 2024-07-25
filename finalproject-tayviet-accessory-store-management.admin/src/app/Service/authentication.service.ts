import { Injectable } from '@angular/core';
import { IAccount } from '../Interface/iaccount';
@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private userID = 'none';

  constructor() { }

  setToken(user : IAccount): void {
    localStorage.setItem(this.userID, user.id);
  }

  getToken(): any | null {
    if (localStorage.getItem(this.userID) === 'none') {
      return null;
    }
    return { userID: localStorage.getItem(this.userID) } 
  }

  removeToken(): void {
    localStorage.setItem(this.userID, 'none');
  }

  isLoggedIn(): boolean {
    if (localStorage.getItem(this.userID) === 'none' ){
      return false;
    }
    return true;
  }

}
