import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IAccount } from '../Interface/iaccount';

@Injectable({
  providedIn: 'root'
})
export class APIService {
  constructor(private http: HttpClient) { }

  getDetailObject(id: string | null, nameObject: string | null) {
    return this.http.get<any>(`/api/${nameObject}/${id}`);
  }
  changeDetailObject(nameObject: string | null, object: any) {
    return this.http.put(`/api/${nameObject}`, object);
  }
  createDetailObject(nameObject: string | null, object: any) {
    return this.http.post(`/api/${nameObject}`, object);
  }
}
