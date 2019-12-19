import { Component, OnInit } from '@angular/core';
import { HomeService } from './services/home.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { finalize } from 'rxjs/operators'
import { AuthService } from '../account/services/auth.service';
import { MatDialog } from '@angular/material/dialog';
import { BoardFormComponent } from './board-form/board-form.component';
import { BoardCard } from './models/boardCard';
import { Board } from './models/board';
import { AccountComponent } from '../navbar/account/account.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  
  cards: BoardCard[];

  constructor(public formDialog: MatDialog, 
    private auth: AuthService, 
    private service: HomeService, 
    private spinner: NgxSpinnerService) {
      
  }

  ngOnInit(){
    this.getCards();
  }

  getCards() {
    this.spinner.show();

    this.service
    .getCards(this.auth.userId)
    .pipe(finalize(() => {
      this.spinner.hide();
    }))
    .subscribe(result => {     
      this.cards = result;
   });
  }

  addBoard() {

    const dialogRef = this.formDialog.open(BoardFormComponent, {
      width: '40%',
      height: '80%',
      data: new BoardCard(this.auth.userId)
    });

    dialogRef.afterClosed().subscribe(result => {
      if(result != null && result != undefined){
        this.service.post(result).subscribe(data => {
          if(this.cards == null){
            this.cards = [];
          }
          this.cards.unshift(data);
        })
      }
    });
  }

  editBoard(card: BoardCard) {
    this.service.put(card.board).subscribe(result => {
      this.getCards();
    })
  }

  deleteBoard(card: BoardCard) {
    this.service.delete(card.board).subscribe(result => {
      this.getCards();
    })
  }
}
