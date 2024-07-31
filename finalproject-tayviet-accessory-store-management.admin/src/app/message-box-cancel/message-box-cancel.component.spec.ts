import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MessageBoxCancelComponent } from './message-box-cancel.component';

describe('MessageBoxCancelComponent', () => {
  let component: MessageBoxCancelComponent;
  let fixture: ComponentFixture<MessageBoxCancelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MessageBoxCancelComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MessageBoxCancelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
