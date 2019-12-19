import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/account/services/auth.service';
import { AccountService } from '../services/account.service';
import { UserAccount } from '../models/userAccount';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.scss']
})
export class AccountComponent implements OnInit {

  userAccount: UserAccount;

  name: string;

  file: File;

  constructor(private auth: AuthService, private service: AccountService) { }

  ngOnInit() {
    
  }

  getUserAccount(){
    this.service.getUserAccount(this.auth.userId).subscribe(result => {
      this.userAccount = result;
    });
  }

  save(){
    this.service.put(this.userAccount).subscribe(result => {
      console.log("asdasdasdasd")
    });
  }

}
