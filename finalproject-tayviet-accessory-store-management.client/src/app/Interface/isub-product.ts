export interface ISubProduct {
  name: string;
  description: string;
  listImage: string[];
  inStock: number;
  state?: string;
  buyCost: number;
  sellCost: number;
  discount: number;
}
export class SubProduct implements ISubProduct {
  public name: string = '';
  public description: string = '';
  public listImage: string[] = [];
  public inStock: number = 0;
  public state: string = '';
  public buyCost: number = 0;
  public sellCost: number = 0;
  public discount: number = 0;
}
