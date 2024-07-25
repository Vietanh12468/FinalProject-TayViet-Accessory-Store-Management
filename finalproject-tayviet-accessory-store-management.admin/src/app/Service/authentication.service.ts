import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private userIDKey = 'none';
  private userRoleKey = 'none';

  constructor() { }

  setToken(userID: string, role: string): void {
    localStorage.setItem(this.userIDKey, userID);
    localStorage.setItem(this.userRoleKey, role);
  }

  getToken(): any | null {
    if (localStorage.getItem(this.userIDKey) === 'none' || localStorage.getItem(this.userRoleKey) === 'none') {
      return null;
    }
    return { userID: localStorage.getItem(this.userIDKey), role: localStorage.getItem(this.userRoleKey) } 
  }

  removeToken(): void {
    localStorage.setItem(this.userIDKey, 'none');
    localStorage.setItem(this.userRoleKey, 'none');
  }

  isLoggedIn(): boolean {
    if (localStorage.getItem(this.userIDKey) === 'none' || localStorage.getItem(this.userRoleKey) === 'none') {
      return false;
    }
    return true;
  }

}
