import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private baseUrl = 'https://localhost:7297/'; 

  constructor(private http: HttpClient) { }

  getItems(): Observable<any> {
    return this.http.get(`${this.baseUrl}/items`);
  }

  getItem(id: number): Observable<any> {
    return this.http.get(`${this.baseUrl}/items/${id}`);
  }

  createItem(item: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/items`, item);
  }

  updateItem(id: number, item: any): Observable<any> {
    return this.http.put(`${this.baseUrl}/items/${id}`, item);
  }

  deleteItem(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/items/${id}`);
  }
}
