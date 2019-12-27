import { TestBed } from '@angular/core/testing';

import { FileCategoryService } from './file-category.service';

describe('FileCategoryService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: FileCategoryService = TestBed.get(FileCategoryService);
    expect(service).toBeTruthy();
  });
});
