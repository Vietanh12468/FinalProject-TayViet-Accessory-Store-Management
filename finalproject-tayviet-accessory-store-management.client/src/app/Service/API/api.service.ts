import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IAccount } from '../../Interface/iaccount';
import { IProduct } from '../../Interface/iproduct';

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
  deleteDetailObject(nameObject: string | null, id: string | null) {
    return this.http.delete(`/api/${nameObject}/${id}`);
  }

  getListObjects(nameObject: string | null, page: number) {
    return this.http.get<any>(`/api/${nameObject}/page/${page}`);
  }

  searchListObjects(nameObject: string | null, searchAttribute: string | null, keyword: string | null, page: number) {
    return this.http.get<any>(`/api/${nameObject}/search/attribute=${searchAttribute}&key=${keyword}&page=${page}`);
  }
  loginRequest(loginData: any) {
    return this.http.post<IAccount>(`/api/Customer/login`, loginData);
  }


  getLatestProducts() {
    return this.http.get<IProduct[]>(`/api/Product/Latest`);
  }
  getAllCategories() {
    return this.http.get<any>(`/api/CategorySection`);
  }

  addToCart(customerId: string, productId: string | undefined, subProductName: string, quantity: number) {
    return this.http.put(`/api/Customer/${customerId}/addProductInCart/productId=${productId}&subProductName=${subProductName}&quantity=${quantity}`, null);
  }
}
