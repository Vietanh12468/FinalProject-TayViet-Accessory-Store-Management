export interface ICategory {
  id: string;
  name: string;
  categoryList: string[];
}

export class Category implements ICategory {
  id: string;
  name: string;
  categoryList: string[];

  constructor() {
    this.id = '';
    this.name = '';
    this.categoryList = [];
  }
}
