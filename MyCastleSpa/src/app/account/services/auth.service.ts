import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { UserManager, User } from 'oidc-client';
import { BaseService } from 'src/app/baseService';
import { catchError } from 'rxjs/operators';
import { ConfigService } from 'src/app/configService';
import { HttpClient } from '@angular/common/http';
import { UserRegister } from '../models/userRegister';

@Injectable({
  providedIn: 'root',
})
export class AuthService extends BaseService  {

  private _authNavStatusSource = new BehaviorSubject<boolean>(false);
  authNavStatus$ = this._authNavStatusSource.asObservable();

  manager = new UserManager(this.configService.getClientSettings);
  private user: User | null;

  constructor(private http: HttpClient, private configService: ConfigService) { 
    super();

    this.manager.getUser().then(user => { 
      this.user = user;      
      this._authNavStatusSource.next(this.isAuthenticated());
    });
  }

  login() {
    return this.manager.signinRedirect();   
  }

  async completeAuthentication() {
      this.user = await this.manager.signinRedirectCallback();
      this._authNavStatusSource.next(this.isAuthenticated());      
  }  

  register(userRegistration: UserRegister) {   
    console.log(userRegistration); 
    return this.http.put(this.configService.authService + '/register', userRegistration).pipe(catchError(this.handleError));
  }

  isAuthenticated(): boolean {
    return this.user != null && !this.user.expired;
  }

  get authorizationHeaderValue(): string {
    return `${this.user.token_type} ${this.user.access_token}`;
  }

  get name(): string {
    return this.user != null ? this.user.profile.name : '';
  }

  get userId(): string {
    return this.user != null ? this.user.profile.sub : '';
  }

  signout() {
    this.manager.signoutRedirect();
  }
}