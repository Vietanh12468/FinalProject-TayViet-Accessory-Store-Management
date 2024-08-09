import { Component, OnInit, ViewChild, OnChanges, SimpleChanges } from '@angular/core';
import { ICategory, Category } from '../../Interface/icategory';
import { SelectOption } from '../../Interface/iselect-option';
import { TableComponent } from '../../Component/table/table.component';
import { Router } from '@angular/router';
import { APIService } from '../../Service/API/api.service';
import { MatSnackBar } from '@angular/material/snack-bar'; // Import MatSnackBar

@Component({
  selector: 'app-category-manager-view',
  templateUrl: './category-manager-view.component.html',
  styleUrls: ['./category-manager-view.component.css'] // Corrected the typo here
})
export class CategoryManagerViewComponent implements OnInit, OnChanges {
  @ViewChild('tableComponent') tableComponent!: TableComponent;
  data: ICategory[] = [];
  total: number = 0;
  objectName: string = 'CategorySection';
  selectOptions: SelectOption[] = [];
  ignoredAttributes: string[] = [];
  mode = 'view';

  constructor(
    private apiService: APIService,
    private router: Router,
    private snackBar: MatSnackBar // Inject MatSnackBar
  ) { }

  ngOnInit() {
    this.getCategories();
  }

  ngOnChanges(simpleChanges: SimpleChanges) { }

  getCategories(page: number = 1) {
    this.apiService.getListObjects(this.objectName, page).subscribe(
      (result) => {
        this.data = result.data;
        this.total = result.total;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  onAddCategorySectionClick() {
    const newCategory = new Category();
    newCategory.name = 'New Category Section';
    newCategory.categoryList = ['New Category'];
    this.apiService.createDetailObject(this.objectName, newCategory).subscribe(
      response => {
        console.log('POST request successful', response);
        this.getCategories();

        // Show success notification
        this.snackBar.open('Add successful!', 'Close', {
          duration: 3000,
          verticalPosition: 'top',
          horizontalPosition: 'right',
        });
      },
      error => {
        console.error('Error occurred', error);
      }
    );
  }

  onDeleteCategorySection(index: number) {
    const categorySectionDelete = this.data[index];
    this.apiService.deleteDetailObject(this.objectName, categorySectionDelete.id).subscribe(
      response => {
        this.data.splice(index, 1);
        console.log('DELETE request successful', response);

        // Show success notification
        this.snackBar.open('Delete successful!', 'Close', {
          duration: 3000,
          verticalPosition: 'top',
          horizontalPosition: 'right',
        });
      },
      error => {
        console.error('Error occurred', error);
      }
    );
  }

  onAddCategory(index: number) {
    const categoryListTemp = this.data[index];
    categoryListTemp.categoryList.push('new category');
    this.apiService.changeDetailObject(this.objectName, categoryListTemp).subscribe(
      response => {
        this.data[index] = categoryListTemp;
        console.log('PUT request successful', response);

        // Show success notification
        this.snackBar.open('Save successful!', 'Close', {
          duration: 3000,
          verticalPosition: 'top',
          horizontalPosition: 'right',
        });
      },
      error => {
        console.error('Error occurred', error);
      }
    );
  }

  onDeleteCategory(position: any) {
    const categoryListTemp = this.data[position.x];
    categoryListTemp.categoryList.splice(position.y, 1);
    this.apiService.changeDetailObject(this.objectName, categoryListTemp).subscribe(
      response => {
        this.data[position.x] = categoryListTemp;
        console.log('PUT request successful', response);

        // Show success notification
        this.snackBar.open('Save successful!', 'Close', {
          duration: 3000,
          verticalPosition: 'top',
          horizontalPosition: 'right',
        });
      },
      error => {
        console.error('Error occurred', error);
      }
    );
  }

  onChangeCategory(categoryInfo: any) {
    const categoryListTemp = this.data[categoryInfo.x];
    if (categoryListTemp.categoryList.includes(categoryInfo.categoryName)) {
      categoryInfo.categoryName = categoryListTemp.categoryList[categoryInfo.y];
      console.log('Category name already exists');
    }
    categoryListTemp.categoryList[categoryInfo.y] = categoryInfo.categoryName;

    this.apiService.changeDetailObject(this.objectName, categoryListTemp).subscribe(
      response => {
        this.data[categoryInfo.x] = categoryListTemp;
        console.log('PUT request successful', response);

        // Show success notification
        this.snackBar.open('Save successful!', 'Close', {
          duration: 3000,
          verticalPosition: 'top',
          horizontalPosition: 'right',
        });
      },
      error => {
        console.error('Error occurred', error);
      }
    );
  }

  onEditClick() {
    this.mode = 'change';
  }

  exitEditClick() {
    this.mode = 'view';
  }

  onChangecategoryName(categoryInfo: any) {
    const categoryListTemp = this.data[categoryInfo.x];
    categoryListTemp.name = categoryInfo.nameSection;
    this.apiService.changeDetailObject(this.objectName, categoryListTemp).subscribe(
      response => {
        this.data[categoryInfo.x] = categoryListTemp;
        console.log('PUT request successful', response);

        // Show success notification
        this.snackBar.open('Save successful!', 'Close', {
          duration: 3000,
          verticalPosition: 'top',
          horizontalPosition: 'right',
        });
      },
      error => {
        console.error('Error occurred', error);
      }
    );
  }
}
