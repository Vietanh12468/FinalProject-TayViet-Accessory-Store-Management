export interface ICategory {
  id: string | null;
  name: string;
  categoryList: string[];
}

export class Category implements ICategory {
  id: string | null;
  name: string;
  categoryList: string[];

  constructor() {
    this.id = null;
    this.name = '';
    this.categoryList = [];
  }
}
