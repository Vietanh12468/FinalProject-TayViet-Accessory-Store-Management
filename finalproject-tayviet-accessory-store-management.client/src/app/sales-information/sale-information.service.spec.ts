import { TestBed } from '@angular/core/testing';

import { SaleInformationService } from './sale-information.service';

describe('SaleInformationService', () => {
  let service: SaleInformationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SaleInformationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
