import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MessageBoxCloseComponent } from './message-box-close.component';

describe('MessageBoxCloseComponent', () => {
  let component: MessageBoxCloseComponent;
  let fixture: ComponentFixture<MessageBoxCloseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MessageBoxCloseComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MessageBoxCloseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
