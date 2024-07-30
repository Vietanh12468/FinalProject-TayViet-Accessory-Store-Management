import { TestBed } from '@angular/core/testing';

import { UnAuthenticationGuardService } from './un-authentication-guard.service';

describe('UnAuthenticationGuardService', () => {
  let service: UnAuthenticationGuardService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UnAuthenticationGuardService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
