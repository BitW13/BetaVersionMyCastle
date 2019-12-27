import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { FileCard } from '../models/fileCard';
import {File } from '../models/file';

@Injectable({
  providedIn: 'root'
})
export class FileService {

  private url = 'http://localhost:51403/api/file/';
  constructor(private http: HttpClient) { }

  getCards(): Observable<FileCard[]> {
    return this.http.get<FileCard[]>(this.url);
  }

  getCard(item: FileCard): Observable<FileCard> {
    return this.http.get<FileCard>(this.url + item.file.id);
  }

  post(item: File): Observable<FileCard> {
    return this.http.post<FileCard>(this.url, item);
  }

  delete(item: File) {
    this.http.delete(this.url + item.id);
  }

  put(item: File): Observable<FileCard> {
    return this.http.put<FileCard>(this.url + item.id, item);
  }
}
