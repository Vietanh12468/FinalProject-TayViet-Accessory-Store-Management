import { Component, Input, Output, EventEmitter, OnInit, OnChanges, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-category-tag',
  templateUrl: './category-tag.component.html',
  styleUrl: './category-tag.component.css'
})
export class CategoryTagComponent implements OnInit, OnChanges {
  @Input() category: string = '';
  @Input() mode: string = 'view';
  @Input() index: number = 0;
  @Output() categoryDeteleTrigger = new EventEmitter<number>();
  @Output() categoryChangeTrigger = new EventEmitter<any>();


  ngOnInit(): void {
  }
  ngOnChanges(changes: SimpleChanges): void {
  }

  constructor() { }

  editCategoryMode: boolean = false;
  editCategory() {
    this.editCategoryMode = true;
  }
  deleteCategory() {
    this.categoryDeteleTrigger.emit(this.index);
  };
  saveCategory() {
    const category = { y: this.index, categoryName: this.category };
    this.editCategoryMode = false;
    this.categoryChangeTrigger.emit(category);
  }
}
