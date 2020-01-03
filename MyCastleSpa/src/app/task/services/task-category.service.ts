import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TaskCategory } from '../models/taskCategory';

@Injectable({
  providedIn: 'root'
})
export class TaskCategoryService {

  private url = 'https://localhost:44369/api/taskcategory/';

  constructor(private http: HttpClient) { }

  getItems(): Observable<TaskCategory[]> {
    return this.http.get<TaskCategory[]>(this.url);
  }

  getItem(item: TaskCategory): Observable<TaskCategory>  {
    return this.http.get<TaskCategory>(this.url + item.id);
  }

  post(item: TaskCategory): Observable<TaskCategory> {
    return this.http.post<TaskCategory>(this.url, item);
  }

  put(item: TaskCategory): Observable<TaskCategory> {
    return this.http.put<TaskCategory>(this.url + item.id, item);
  }

  delete(item: TaskCategory): Observable<TaskCategory> {
    return this.http.delete<TaskCategory>(this.url + item.id);
  }
}
