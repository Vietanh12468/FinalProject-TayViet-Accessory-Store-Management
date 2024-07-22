import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailAccountViewComponent } from './detail-account-view.component';

describe('DetailAccountViewComponent', () => {
  let component: DetailAccountViewComponent;
  let fixture: ComponentFixture<DetailAccountViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DetailAccountViewComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DetailAccountViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
