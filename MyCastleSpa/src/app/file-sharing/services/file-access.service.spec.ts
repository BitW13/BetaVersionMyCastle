import { TestBed } from '@angular/core/testing';

import { FileAccessService } from './file-access.service';

describe('FileAccessService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: FileAccessService = TestBed.get(FileAccessService);
    expect(service).toBeTruthy();
  });
});
