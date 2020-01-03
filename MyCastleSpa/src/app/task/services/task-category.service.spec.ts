import { TestBed } from '@angular/core/testing';

import { TaskCategoryService } from './task-category.service';

describe('TaskCategoryService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: TaskCategoryService = TestBed.get(TaskCategoryService);
    expect(service).toBeTruthy();
  });
});
