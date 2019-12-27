import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FileAccess } from '../models/fileAccess';
import { FileAccessService } from '../services/file-access.service';

@Component({
  selector: 'app-file-access-item',
  templateUrl: './file-access-item.component.html',
  styleUrls: ['./file-access-item.component.scss']
})
export class FileAccessItemComponent implements OnInit {

  @Input() fileAccess :FileAccess;

  @Output() deleteFileAccess = new EventEmitter<FileAccess>();

  @Output() loadItems = new EventEmitter();

  saveItemValue: FileAccess;

  constructor(private fileAccessService: FileAccessService) { }

  ngOnInit() {
    this.saveItemValue = this.getCopy(this.fileAccess)
  }

  edit() {    
    this.saveItemValue = this.getCopy(this.fileAccess);
  }

  save() {

    this.saveItemValue = null;
    
    this.fileAccessService.put(this.fileAccess).subscribe(data =>{
      this.fileAccess = data;
      this.loadItems.emit();
    });
  }

  cancel() {

    this.fileAccess = this.getCopy(this.saveItemValue);
    
    this.saveItemValue = null;
  }

  delete() {
    this.deleteFileAccess.emit(this.fileAccess);
  }

  getCopy(item: FileAccess) : FileAccess {
    
    let copy = new FileAccess();

    copy.id = item.id;
    copy.name = item.name;

    return copy;
  }
}
