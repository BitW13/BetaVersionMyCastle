import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FileCategory } from '../models/fileCategory';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FileCategoryService {

  private url = 'http://localhost:51403/api/filecategory/';

  constructor(private http: HttpClient) { }

  getItems(): Observable<FileCategory[]> {
    return this.http.get<FileCategory[]>(this.url);
  }

  getItem(item: FileCategory): Observable<FileCategory>  {
    return this.http.get<FileCategory>(this.url + item.id);
  }

  post(item: FileCategory): Observable<FileCategory> {
    return this.http.post<FileCategory>(this.url, item);
  }

  put(item: FileCategory): Observable<FileCategory> {
    return this.http.put<FileCategory>(this.url + item.id, item);
  }

  delete(item: FileCategory): Observable<FileCategory> {
    return this.http.delete<FileCategory>(this.url + item.id);
  }
}
