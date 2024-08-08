import { Component, Input } from '@angular/core';
import { ICategory } from '../../Interface/icategory';
@Component({
  selector: 'app-category-option',
  templateUrl: './category-option.component.html',
  styleUrl: './category-option.component.css'
})
export class CategoryOptionComponent {
  @Input() categorySections: ICategory[] = [];

}
