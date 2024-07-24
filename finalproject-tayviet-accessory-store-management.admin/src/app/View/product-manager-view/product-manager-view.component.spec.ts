import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductManagerViewComponent } from './product-manager-view.component';

describe('ProductManagerViewComponent', () => {
  let component: ProductManagerViewComponent;
  let fixture: ComponentFixture<ProductManagerViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ProductManagerViewComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ProductManagerViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
