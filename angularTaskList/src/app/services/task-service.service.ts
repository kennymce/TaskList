import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {observable, Observable, Subscriber} from 'rxjs';
import { of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { TaskList } from '../models/TaskList';
import { TaskStatus } from '../models/TaskStatus';

@Injectable({
  providedIn: 'root'
})
export class TaskServiceService {

  private APIPath = 'http://localhost:5000/api/';
  constructor(private http: HttpClient) {}
  getTasks(): Observable<TaskList[]> {
    return this.http.get<TaskList[]>(this.APIPath + 'Tasks');
  }

  getTaskStatuses(): Observable<TaskStatus[]> {
    return this.http.get<TaskStatus[]>(this.APIPath + 'TaskListStatus');
  }

  createNewTask(task: TaskList): Observable<TaskList> {
    return this.http.post<TaskList>(this.APIPath + 'Tasks', task);
  }

  updateTask(task: TaskList) {
    return this.http.put<TaskList>(this.APIPath + `Tasks/${task.taskId}`, task);
  }
}
