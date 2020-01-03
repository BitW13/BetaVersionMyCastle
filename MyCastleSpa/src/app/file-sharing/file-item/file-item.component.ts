import { Component, OnInit, EventEmitter, Input, Output } from '@angular/core';
import { FileService } from '../services/file.service';
import { FileCategory } from '../models/fileCategory';
import { FileCard } from '../models/fileCard';
import { File } from '../models/file';
import { FileAccess } from '../models/fileAccess';

@Component({
  selector: 'app-file-item',
  templateUrl: './file-item.component.html',
  styleUrls: ['./file-item.component.scss'],
  providers:[FileService]
})
export class FileItemComponent implements OnInit {

  @Input() card: FileCard;

  @Input() categories: FileCategory[];

  @Input() fileAccesses: FileAccess[];

  @Output() deleteFile = new EventEmitter<FileCard>();

  isEditFile: boolean = false;

  saveItemValue: File;

  constructor(private fileService: FileService) {}

  ngOnInit() {
  }

  switchingIsEditItem(){
    this.isEditFile = !this.isEditFile;
  }

  edit() {

    this.switchingIsEditItem();
    
    this.saveItemValue = this.getCopy(this.card.file);
  }

  save() {

    this.saveItemValue = null;

    this.switchingIsEditItem();
    
    this.fileService.put(this.card.file).subscribe(data => this.card = data);
  }

  cancel() {

    this.card.file = this.getCopy(this.saveItemValue);
    
    this.saveItemValue = null;

    this.switchingIsEditItem();
  }

  delete() {
    this.deleteFile.emit(this.card);
  }

  getCopy(item: File): File {

    let copy = new File();

    copy.id = item.id;
    copy.name = item.name;
    copy.description = item.description;
    copy.downloadDate = item.downloadDate;
    copy.categoryId = item.categoryId;
    copy.fileAccessId = item.fileAccessId;
    copy.size = item.size;

    return copy;
  }
}
