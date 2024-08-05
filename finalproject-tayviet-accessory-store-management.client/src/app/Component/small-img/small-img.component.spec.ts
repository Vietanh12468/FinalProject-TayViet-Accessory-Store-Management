import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SmallImgComponent } from './small-img.component';

describe('SmallImgComponent', () => {
  let component: SmallImgComponent;
  let fixture: ComponentFixture<SmallImgComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SmallImgComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SmallImgComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
