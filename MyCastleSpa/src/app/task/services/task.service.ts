import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TaskCard } from '../models/taskCard';
import { Observable } from 'rxjs';
import { Task } from '../models/task';

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  private url ="https://localhost:44369/api/task/";

  constructor(private http:HttpClient) { }

  getCards(): Observable<TaskCard[]> {
    return this.http.get<TaskCard[]>(this.url);
  }

  getCard(item: TaskCard): Observable<TaskCard>  {
    return this.http.get<TaskCard>(this.url + item.task.id);
  }

  post(item: Task): Observable<TaskCard> {
    return this.http.post<TaskCard>(this.url, item);
  }

  put(item: Task): Observable<TaskCard> {
    return this.http.put<TaskCard>(this.url + item.id, item);
  }

  delete(item: Task): Observable<TaskCard> {
    return this.http.delete<TaskCard>(this.url + item.id);
  }
}
