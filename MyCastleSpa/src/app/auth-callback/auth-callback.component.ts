import { Component, OnInit } from '@angular/core';
import { AuthService } from '../account/services/auth.service';
import { Router, ActivatedRoute } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-auth-callback',
  templateUrl: './auth-callback.component.html',
  styleUrls: ['./auth-callback.component.scss']
})
export class AuthCallbackComponent implements OnInit {

  error: boolean;

  constructor(private authService: AuthService, private router: Router, private route: ActivatedRoute, private spinner: NgxSpinnerService) {}

  async ngOnInit() {
    if (this.route.snapshot.fragment.indexOf('error') >= 0) {
      this.error=true; 
      return;    
    }
   
   await this.authService.completeAuthentication();      
   this.router.navigate(['/home']);
  } 

  login() {
    this.spinner.show();
    this.authService.login();
  }
}
