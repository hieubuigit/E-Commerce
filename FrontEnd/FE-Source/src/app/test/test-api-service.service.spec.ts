import { TestBed } from '@angular/core/testing';

import { TestApiServiceService } from './test-api-service.service';

describe('TestApiServiceService', () => {
  let service: TestApiServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TestApiServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
