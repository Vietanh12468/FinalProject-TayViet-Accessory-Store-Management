import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-category-tag',
  templateUrl: './category-tag.component.html',
  styleUrl: './category-tag.component.css'
})
export class CategoryTagComponent {
  @Input() category: string = '';
  @Input() mode: string = 'view';
  @Input() index: number = 0;
  @Output() categoryDeteleTrigger = new EventEmitter<number>();

  deleteCategory() {
    this.categoryDeteleTrigger.emit(this.index);
  };
}
