import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ProgressStatus, ProgressStatusEnum } from 'src/app/file-sharing/models/progress-status.model';
import { UploadDownloadService } from '../services/upload-download.service';
import { HttpEventType } from '@angular/common/http';

@Component({
  selector: 'app-download',
  templateUrl: './download.component.html',
  styleUrls: ['./download.component.scss']
})
export class DownloadComponent {
  @Input() public disabled: boolean;
  @Input() public fileName: string;
  @Output() public downloadStatus: EventEmitter<ProgressStatus>;

  constructor(private service: UploadDownloadService) {
    this.downloadStatus = new EventEmitter<ProgressStatus>();
   }

   public download() {
     this.downloadStatus.emit( {status: ProgressStatusEnum.START});
     this.service.downloadFile(this.fileName).subscribe(
       data => {
         switch(data.type) {
            case HttpEventType.DownloadProgress:
             this.downloadStatus.emit({status: ProgressStatusEnum.IN_PROGRESS, percentage: Math.round((data.loaded / data.total) * 100)});
             break;
            case HttpEventType.Response:
              this.downloadStatus.emit( {status: ProgressStatusEnum.COMPLETE});
              const downloadedFile = new Blob([data.body], {type: data.body.type});
              const a = document.createElement('a');
              a.setAttribute('style', 'display: none;');
              document.body.appendChild(a);
              a.download = this.fileName;
              a.href = URL.createObjectURL(downloadedFile);
              a.target = '_blank';
              a.click();
              document.body.removeChild(a);
              break;
         }
       },
       error => {
         this.downloadStatus.emit( {status: ProgressStatusEnum.ERROR});
       }       
     );
   }

}
