import { Injectable } from '@angular/core';
import { HttpClient, HttpEvent, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';
import { FileCard } from '../models/fileCard';

@Injectable({
  providedIn: 'root'
})
export class UploadDownloadService {
  private baseApiUrl: string;
  private apiDownloadUrl: string;
  private apiUploadUrl: string;
  private apiFileUrl: string;

  constructor(private httpClient: HttpClient) {
    this.baseApiUrl = 'http://localhost:51403/api/';
    this.apiDownloadUrl = this.baseApiUrl + 'files/download';
    this.apiUploadUrl = this.baseApiUrl + 'files/upload';
    this.apiFileUrl = this.baseApiUrl + 'files';
   }

  public downloadFile(file: string): Observable<HttpEvent<Blob>> {
    return this.httpClient.request(new HttpRequest(
      'GET',
      `${this.apiDownloadUrl}?file=${file}`,
      null,
      {
        reportProgress: true,
        responseType: 'blob'
      }));
  }

  public uploadFile(file: Blob, fileData: FileCard): Observable<HttpEvent<void>>{
    
    const formData = new FormData();    
    formData.append('file', file);
    formData.append('description', fileData.file.description);
    formData.append('categoryId', fileData.fileCategory.id as any as string);
    formData.append('accessId', fileData.fileAccess.id as any as string);

    return this.httpClient.request(new HttpRequest(
      'POST',
      this.apiUploadUrl,
      formData,
      {
        reportProgress: true
      }));
   }

   public getFiles(): Observable<string[]> {
     return this.httpClient.get<string[]>(this.apiFileUrl);
   }
}
