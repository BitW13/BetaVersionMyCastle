import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { FileAccess } from '../models/fileAccess';

@Injectable({
  providedIn: 'root'
})
export class FileAccessService {
  
  private url = 'http://localhost:51403/api/fileaccess/';

  constructor(private http: HttpClient) { }

  getItems(): Observable<FileAccess[]> {
    return this.http.get<FileAccess[]>(this.url);
  }

  getItem(item: FileAccess): Observable<FileAccess>  {
    return this.http.get<FileAccess>(this.url + item.id);
  }

  post(item: FileAccess): Observable<FileAccess> {
    return this.http.post<FileAccess>(this.url, item);
  }

  put(item: FileAccess): Observable<FileAccess> {
    return this.http.put<FileAccess>(this.url + item.id, item);
  }

  delete(item: FileAccess): Observable<FileAccess> {
    return this.http.delete<FileAccess>(this.url + item.id);
  }
}
