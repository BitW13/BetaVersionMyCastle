import { Component, OnInit, Inject, Input } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Board } from '../models/board';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { BoardCard } from '../models/boardCard';

@Component({
  selector: 'app-board-form',
  templateUrl: './board-form.component.html',
  styleUrls: ['./board-form.component.scss']
})
export class BoardFormComponent {

  validationForm: FormGroup;

  @Input() board: Board;

  constructor(
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<BoardFormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: BoardCard) 
  {
    this.initValidationForm(data);
  }

  initValidationForm(data: BoardCard){
    if(data.board.id <= 0){
      this.validationForm = this.fb.group({
        name: new FormControl("", [Validators.required]),
        imagePath: new FormControl("", [Validators.required]),
        color: new FormControl("#3d18e7", [Validators.required]),
        isFavorite: new FormControl()
      })
    }
  }

  save(){
    this.data.board = this.validationForm.value;
    this.dialogRef.close(this.data);
  }

  cancel(): void {
    this.dialogRef.close();
  }

}
