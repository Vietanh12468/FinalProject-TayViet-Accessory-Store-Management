import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubProductCarouselComponent } from './sub-product-carousel.component';

describe('SubProductCarouselComponent', () => {
  let component: SubProductCarouselComponent;
  let fixture: ComponentFixture<SubProductCarouselComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SubProductCarouselComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SubProductCarouselComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
