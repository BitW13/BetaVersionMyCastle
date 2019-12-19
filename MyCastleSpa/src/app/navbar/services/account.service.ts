import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConfigService } from 'src/app/configService';
import { BaseService } from 'src/app/baseService';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { UserAccount } from '../models/userAccount';

@Injectable({
  providedIn: 'root'
})
export class AccountService extends BaseService{

  private url: string;

  constructor(private http: HttpClient, private configService: ConfigService) {    
    super();   
    this.url = this.configService.profileService + '/api/account/';
  }
  
  getUserAccount(userId: string): Observable<UserAccount> {
    return this.http.get<UserAccount>(this.url + userId).pipe(catchError(this.handleError))
  }

  put(item: UserAccount): Observable<UserAccount> {
    return this.http.put<UserAccount>(this.url, item).pipe(catchError(this.handleError));
  }
}
