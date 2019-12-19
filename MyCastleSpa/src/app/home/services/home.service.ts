import { Injectable } from '@angular/core';
import { BaseService } from 'src/app/baseService';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { ConfigService } from 'src/app/configService';
import { Observable } from 'rxjs';
import { BoardCard } from '../models/boardCard';
import { CreateBoard } from '../models/createBoard';
import { Board } from '../models/board';

@Injectable({
  providedIn: 'root'
})
export class HomeService extends BaseService {

  private url: string;

  constructor(private http: HttpClient, private configService: ConfigService) {    
    super();   
    this.url = this.configService.profileService + '/api/profile/';
  }

  getCards(userId: string):Observable<BoardCard[]> {
    console.log(userId);
    return this.http.get<BoardCard[]>(this.url + userId).pipe(catchError(this.handleError));
  }

  post(item: CreateBoard): Observable<BoardCard> {
    return this.http.post<BoardCard>(this.url, item).pipe(catchError(this.handleError));
  }

  delete(board: Board): Observable<BoardCard> {
    return this.http.delete<BoardCard>(this.url + board.id).pipe(catchError(this.handleError));
  }

  put(item: Board): Observable<BoardCard> {
    return this.http.put<BoardCard>(this.url + item.id, item).pipe(catchError(this.handleError));
  }
}