import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailProductViewComponent } from './detail-product-view.component';

describe('DetailProductViewComponent', () => {
  let component: DetailProductViewComponent;
  let fixture: ComponentFixture<DetailProductViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DetailProductViewComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DetailProductViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
