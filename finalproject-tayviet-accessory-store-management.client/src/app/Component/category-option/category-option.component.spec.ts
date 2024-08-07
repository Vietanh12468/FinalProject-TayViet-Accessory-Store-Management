import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoryOptionComponent } from './category-option.component';

describe('CategoryOptionComponent', () => {
  let component: CategoryOptionComponent;
  let fixture: ComponentFixture<CategoryOptionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CategoryOptionComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CategoryOptionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
