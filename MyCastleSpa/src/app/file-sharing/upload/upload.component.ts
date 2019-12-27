import { Component, Input, Output, ViewChild, ElementRef, EventEmitter } from '@angular/core';
import { UploadDownloadService } from '../services/upload-download.service';
import { ProgressStatus, ProgressStatusEnum } from 'src/app/file-sharing/models/progress-status.model';
import { HttpEventType } from '@angular/common/http';
import { FileService } from '../services/file.service';
import { File } from '../models/file';
import { FileCard } from '../models/fileCard';
import { FileCategory } from '../models/fileCategory';
import { FileAccess } from '../models/fileAccess';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.scss']
})
export class UploadComponent {
  @Input() public disabled: boolean;
  @Output() public uploadStatus: EventEmitter<ProgressStatus>;
  @ViewChild('inputFile', {static: false}) inputFile: ElementRef;

  file: File = new File();
  fileCategory: FileCategory;
  fileAccess: FileAccess;
  
  @Input() categories: FileCategory[];
  @Input() fileAccesses: FileAccess[];

  constructor(private service: UploadDownloadService, private fileService: FileService) {
    this.uploadStatus = new EventEmitter<ProgressStatus>();
   }

   public upload(event) {
     if(event.target.files && event.target.files.length > 0){
       const file = event.target.files[0];
       this.uploadStatus.emit({status: ProgressStatusEnum.START });
       this.file.name = file.name;
       this.file.size = file.size;
       this.fileService.post(this.file).subscribe(data => {});
       this.service.uploadFile(file).subscribe(
         data => {
           if(data) {
             switch (data.type) {
                case HttpEventType.UploadProgress:
                 this.uploadStatus.emit( {status: ProgressStatusEnum.IN_PROGRESS, percentage: Math.round((data.loaded / data.total) * 100)});
                 break;
                case HttpEventType.Response:
                  this.inputFile.nativeElement.value = '';
                  this.uploadStatus.emit( {status: ProgressStatusEnum.COMPLETE });
                  break;
             }
           }
         },
         error => {
           this.inputFile.nativeElement.value = '';
           this.uploadStatus.emit({status: ProgressStatusEnum.ERROR});
         }
       );
     }
   }

}
