import { Component, OnInit, ViewChild, OnChanges, SimpleChanges } from '@angular/core';
import { ICategory, Category } from '../../Interface/icategory';
import { SelectOption } from '../../Interface/iselect-option';
import { TableComponent } from '../../Component/table/table.component';
import { Router } from '@angular/router';
import { APIService } from '../../Service/API/api.service';

@Component({
  selector: 'app-category-manager-view',
  templateUrl: './category-manager-view.component.html',
  styleUrl: './category-manager-view.component.css'
})
export class CategoryManagerViewComponent implements OnInit, OnChanges {
  @ViewChild('tableComponent') tableComponent!: TableComponent;
  data: ICategory[] = [];
  total: number = 0;
  objectName: string = 'CategorySection';
  selectOptions: SelectOption[] = [
  ]

  ignoredAttributes: string[] = [];
  mode = 'view';

  ngOnInit() {
    this.getCategories();
  }

  ngOnChanges(simpleChanges: SimpleChanges) {
  }
  constructor(private apiService: APIService, private router: Router) { }

  getCategories(page: number = 1) {
    this.apiService.getListObjects(this.objectName, page).subscribe(
      (result) => {
        this.data = result.data;
        this.total = result.total;
      },
      (error) => {
        console.error(error);
      }
    )
  }

  onAddCategoryClick() {
    const newCategory = new Category();
    newCategory.id = 'qhuwehqrwuhqweh';
    newCategory.name = 'New Category';
    newCategory.categoryList = ['New Category'];
    this.data.push(newCategory);
    console.log(this.data);
  }

  onEditClick() {
    this.mode = 'change';
  }
  exitEditClick() {
    this.mode = 'view';
  }
}
