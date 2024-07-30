import { SubProduct } from './isub-product';

export interface IProduct {
  id?: string;
  name: string;
  description: string;
  image: string;
  categoryList: string[];
  subProductList: SubProduct[];
  brandID: string;
}

export class Product {
  public id?: string;
  public name: string = '';
  public description: string = '';
  public image: string = '';
  public categoryList: string[] = [];
  public subProductList: SubProduct[] = [];
  public brandID: string = '';
} 
