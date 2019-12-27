import { Component, OnInit } from '@angular/core';
import { ProgressStatusEnum, ProgressStatus } from 'src/app/file-sharing/models/progress-status.model';
import { UploadDownloadService } from './services/upload-download.service';
import { FileCard } from './models/fileCard';
import { FileService } from './services/file.service';
import { FileCategoryService } from './services/file-category.service';
import { FileCategory } from './models/fileCategory';
import { FileAccess } from './models/fileAccess';
import { FileAccessService } from './services/file-access.service';

@Component({
  selector: 'app-file-sharing',
  templateUrl: './file-sharing.component.html',
  styleUrls: ['./file-sharing.component.scss']
})
export class FileSharingComponent implements OnInit {

  public files: FileCard[];
  categories: FileCategory[];
  fileAccesses: FileAccess[];
  public fileInDownload: string;
  public percentage: number;
  public showProgress: boolean;
  public showDownloadError: boolean;
  public showUploadError: boolean;

  isCreateFile: boolean = false;
 
  constructor(private service: UploadDownloadService, 
              private fileService: FileService, 
              private categoryService: FileCategoryService,
              private accessService: FileAccessService) { }

  ngOnInit() {
    this.loadItems();
    console.log(this.fileAccesses);
    console.log(this.categories);
    console.log(this.files);
  }

  loadItems() {
    this.getFiles();
    this.getCategories();
    this.getFileAccesses();
  }

  getCategories() {    
    this.categoryService.getItems().subscribe(data => this.categories = data);
  }

  getFileAccesses() {
    this.accessService.getItems().subscribe(data => this.fileAccesses = data);
  }

  addCategory() {
    this.categoryService.post(new FileCategory()).subscribe((data) => this.categories.push(data));
  }

  private getFiles() {
    this.fileService.getCards().subscribe(
      data => {
        this.files = data;
      }
    );
  }

  switchingIsCreateItem(){
    this.isCreateFile = !this.isCreateFile;
  }

  addFile() {
    this.switchingIsCreateItem();

    // this.fileService.post(new File()).subscribe(data => this.cards.unshift(data));
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
