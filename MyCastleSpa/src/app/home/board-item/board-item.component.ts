import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Board } from '../models/board';
import { BoardCard } from '../models/boardCard';
import { BoardFormComponent } from '../board-form/board-form.component';
import { MatDialog } from '@angular/material/dialog';
import { AuthService } from 'src/app/account/services/auth.service';
import { HomeService } from '../services/home.service';

@Component({
  selector: 'app-board-item',
  templateUrl: './board-item.component.html',
  styleUrls: ['./board-item.component.scss']
})
export class BoardItemComponent implements OnInit {

  @Input() card: BoardCard;

  @Output() deleteBoard = new EventEmitter<BoardCard>();

  constructor(
    public formDialog: MatDialog, 
    private auth: AuthService) { }

  ngOnInit() {
  }

  @Output() editBoard = new EventEmitter<BoardCard>();

  delete(){
    this.deleteBoard.emit(this.card);
  }

  edit(){
    
    const dialogRef = this.formDialog.open(BoardFormComponent, {
      width: '40%',
      height: '80%',
      data: new BoardCard(this.auth.userId)
    });

    dialogRef.afterClosed().subscribe(result => {
      if(result != null && result != undefined){
        let id = this.card.board.id;
        this.card = result as BoardCard;
        this.card.board.id = id;
        this.editBoard.emit(this.card);
      }
    });    
  }
}
