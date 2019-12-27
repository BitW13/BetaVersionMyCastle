import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FileCategory } from '../models/fileCategory';
import { FileCategoryService } from '../services/file-category.service';

@Component({
  selector: 'app-file-category-item',
  templateUrl: './file-category-item.component.html',
  styleUrls: ['./file-category-item.component.scss']
})
export class FileCategoryItemComponent implements OnInit {

  @Input() category :FileCategory;

  @Output() deleteCategory = new EventEmitter<FileCategory>();

  @Output() loadItems = new EventEmitter();

  saveItemValue: FileCategory;

  constructor(private categoryService: FileCategoryService) { }

  ngOnInit() {
    this.saveItemValue = this.getCopy(this.category)
  }

  edit() {    
    this.saveItemValue = this.getCopy(this.category);
  }

  save() {

    this.saveItemValue = null;
    
    this.categoryService.put(this.category).subscribe(data =>{
      this.category = data;
      this.loadItems.emit();
    });
  }

  cancel() {

    this.category = this.getCopy(this.saveItemValue);
    
    this.saveItemValue = null;
  }

  delete() {
    this.deleteCategory.emit(this.category);
  }

  getCopy(item: FileCategory) : FileCategory {
    
    let copy = new FileCategory();

    copy.id = item.id;
    copy.name = item.name;

    return copy;
  }

}
