import { Injectable } from '@angular/core';
import { IAccount } from '../../Interface/iaccount';
@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private userID: string | null = null;

  constructor() { }

  setToken(user : IAccount): void {
    localStorage.setItem(this.userID!, user.id);
  }

  getToken(): any | null {
    return { userID: localStorage.getItem(this.userID!) } 
  }

  removeToken(): void {
    localStorage.removeItem(this.userID!);
  }

  isLoggedIn(): boolean {
    if (localStorage.getItem(this.userID!) === null ){
      return false;
    }
    return true;
  }

}
