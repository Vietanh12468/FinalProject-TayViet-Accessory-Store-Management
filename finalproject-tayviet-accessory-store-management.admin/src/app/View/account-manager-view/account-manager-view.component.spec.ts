import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AccountManagerViewComponent } from './account-manager-view.component';

describe('AccountManagerViewComponent', () => {
  let component: AccountManagerViewComponent;
  let fixture: ComponentFixture<AccountManagerViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AccountManagerViewComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AccountManagerViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
