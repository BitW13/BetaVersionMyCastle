import { TestBed } from '@angular/core/testing';

import { UploadDownloadService } from './upload-download.service';

describe('UploadDownloadService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: UploadDownloadService = TestBed.get(UploadDownloadService);
    expect(service).toBeTruthy();
  });
});
