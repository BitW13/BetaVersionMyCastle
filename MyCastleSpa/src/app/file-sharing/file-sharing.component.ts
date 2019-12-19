import { Component, OnInit } from '@angular/core';
import { ProgressStatusEnum, ProgressStatus } from 'src/app/file-sharing/models/progress-status.model';
import { UploadDownloadService } from './services/upload-download.service';
import { FileCard } from './models/fileCard';
import { FileService } from './services/file.service';

@Component({
  selector: 'app-file-sharing',
  templateUrl: './file-sharing.component.html',
  styleUrls: ['./file-sharing.component.scss']
})
export class FileSharingComponent implements OnInit {

  public files: FileCard[];
  public fileInDownload: string;
  public percentage: number;
  public showProgress: boolean;
  public showDownloadError: boolean;
  public showUploadError: boolean;
 
  constructor(private service: UploadDownloadService, private fileService: FileService) { }

  ngOnInit() {
    this.getFiles();
  }

  private getFiles() {
    this.fileService.getCards().subscribe(
      data => {
        this.files = data;
      }
    );
  }

  public downloadStatus(event: ProgressStatus) {
    switch(event.status) {
      case ProgressStatusEnum.START:
        this.showDownloadError = false;
        break;
      case ProgressStatusEnum.IN_PROGRESS:
        this.showProgress = true;
        this.percentage = event.percentage;
        break;
      case ProgressStatusEnum.COMPLETE:
        this.showProgress = false;
        break;
      case ProgressStatusEnum.ERROR:
        this.showProgress = false;
        this.showUploadError = true;
        break;
    }
  }

  public uploadStatus(event: ProgressStatus) {
    switch (event.status) {
      case ProgressStatusEnum.START:
        this.showUploadError = false;
        break;
      case ProgressStatusEnum.IN_PROGRESS:
        this.showProgress = true;
        this.percentage = event.percentage;
        break;
      case ProgressStatusEnum.COMPLETE:
        this.showProgress = false;
        this.getFiles();
        break;
      case ProgressStatusEnum.ERROR:
        this.showProgress = false;
        this.showUploadError = true;
        break;
    }
  }
}
