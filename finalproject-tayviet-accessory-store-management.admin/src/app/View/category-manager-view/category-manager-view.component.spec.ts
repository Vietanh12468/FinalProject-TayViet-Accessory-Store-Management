import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoryManagerViewComponent } from './category-manager-view.component';

describe('CategoryManagerViewComponent', () => {
  let component: CategoryManagerViewComponent;
  let fixture: ComponentFixture<CategoryManagerViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CategoryManagerViewComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CategoryManagerViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
