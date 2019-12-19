import { Component, OnInit, OnDestroy } from '@angular/core';
import { AuthService } from '../account/services/auth.service';
import { Subscription } from 'rxjs';
import { NgxSpinnerService } from 'ngx-spinner';
import { HomeService } from '../home/services/home.service';
import { MatDialog } from '@angular/material/dialog';
import { AccountComponent } from './account/account.component';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit, OnDestroy {

  name: string;
  isAuthenticated: boolean;
  subscription:Subscription;

  constructor(public formDialog: MatDialog,
    private authService: AuthService, 
    private service: HomeService, 
    private spinner: NgxSpinnerService) { }

  ngOnInit() {
    this.subscription = this.authService.authNavStatus$.subscribe(status => this.isAuthenticated = status);
    this.name = this.authService.name;
  }
  
  login() {
    this.spinner.show();
    this.authService.login();
  }

  signout() {
    this.authService.signout();
  }

  openAccount(){
    const accountPage = this.formDialog.open(AccountComponent, {
      width: '40%',
      height: '80%'
    })
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
