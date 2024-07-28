import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IAccount } from '../../Interface/iaccount';

@Injectable({
  providedIn: 'root'
})
export class APIService {
  constructor(private http: HttpClient) { }

  getDetailObject(nameObject: string | null, id: string | null) {
    return this.http.get<any>(`/api/${nameObject}/${id}`);
  }
  changeDetailObject(nameObject: string | null, object: any) {
    return this.http.put(`/api/${nameObject}`, object);
  }
  createDetailObject(nameObject: string | null, object: any) {
    return this.http.post(`/api/${nameObject}`, object);
  }

  getListObjects(nameObject: string | null, page: number) {
    return this.http.get<any>(`/api/${nameObject}/page/${page}`);
  }

  searchListObjects(nameObject: string | null, searchAttribute: string | null, keyword: string | null, page: number) {
    return this.http.get<any>(`/api/${nameObject}/search/${searchAttribute}&&${keyword}&&${page}`);
  }
  loginRequest(loginData: any) {
    return this.http.post<IAccount>(`/api/Admin/login`, loginData);
  }
}
