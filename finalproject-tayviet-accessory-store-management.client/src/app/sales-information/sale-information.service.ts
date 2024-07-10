import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private baseUrl = 'https://localhost:7297/api/OrderHistory';

  constructor(private http: HttpClient) { }

  getItems(): Observable<any> {
    return this.http.get(`${this.baseUrl}/orderhistory`);
  }

  getItem(id: number): Observable<any> {
    return this.http.get(`${this.baseUrl}/orderhistory/${id}`);
  }
}
