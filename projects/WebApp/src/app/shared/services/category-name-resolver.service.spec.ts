import { TestBed } from '@angular/core/testing';

import { CategoryNameResolverService } from './category-name-resolver.service';

describe('CategoryNameResolverService', () => {
  let service: CategoryNameResolverService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CategoryNameResolverService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
