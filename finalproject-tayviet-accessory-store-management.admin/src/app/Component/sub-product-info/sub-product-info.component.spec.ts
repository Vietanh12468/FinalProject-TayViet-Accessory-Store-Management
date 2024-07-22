import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubProductInfoComponent } from './sub-product-info.component';

describe('SubProductInfoComponent', () => {
  let component: SubProductInfoComponent;
  let fixture: ComponentFixture<SubProductInfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SubProductInfoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SubProductInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
