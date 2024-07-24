import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderManagerViewComponent } from './order-manager-view.component';

describe('OrderManagerViewComponent', () => {
  let component: OrderManagerViewComponent;
  let fixture: ComponentFixture<OrderManagerViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [OrderManagerViewComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(OrderManagerViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
