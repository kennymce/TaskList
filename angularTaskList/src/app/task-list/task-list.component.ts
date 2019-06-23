import { Component, OnInit } from '@angular/core';
import { TaskServiceService } from '../services/task-service.service';
import { TaskList } from '../models/TaskList';
import {TaskStatus} from '../models/TaskStatus';
import {NgForm} from '@angular/forms';

@Component({
  selector: 'app-task-list',
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.less']
})
export class TaskListComponent implements OnInit {

  tasks: TaskList[];
  statuses: TaskStatus[];
  modalHeadingText: string;
  addEditTask: TaskList;
  newTaskAction: boolean;
  actionbuttonText: string;

  constructor(
    private taskService: TaskServiceService
  ) {
    this.modalHeadingText = 'Add Task';
    this.actionbuttonText = 'Add';
  }

  ngOnInit() {
    this.getTaskList();
    this.getTaskStatuses();
    this.newTaskAction = true;
  }

  getTaskList(): void {
    this.taskService
      .getTasks()
      .subscribe( data => {
        this.tasks = data;
        console.log(data);
        console.log(this.tasks);
      }, (error) => console.log(error),
        () => this.addEditTask = this.tasks[0]);
  }

  mapTaskStatusEnum(status: number): string {
    const mappedStatus = this.statuses.find(item => item.taskStatusId === status);
    return (mappedStatus) ? mappedStatus.statusName : 'Invalid Status';
  }

  private getTaskStatuses(): void {
    this.taskService.getTaskStatuses()
      .subscribe( data => {
        this.statuses = data;
        console.log(data);
        console.log(this.statuses);
      });
  }

  doTaskAction(action: string) {
    if (this.newTaskAction) {
      this.taskService.createNewTask(this.addEditTask).subscribe(
        res => {
          console.log(`result: ${res}`);
          this.getTaskList();
        },
        err => {
          console.log(`error: ${err}`);
        }
      );
    } else {
      this.taskService.updateTask(this.addEditTask).subscribe(
        res => {
          console.log(`result: ${res}`);
          this.getTaskList();
        },
        err => {
          console.log(`error: ${err}`);
        }
      );
    }
  }

  addNewTask() {
    this.newTaskAction = true;
    this.addEditTask = new TaskList();
    this.actionbuttonText = 'Add';
    this.modalHeadingText = 'Add Task';
  }

  editTask(task: TaskList) {
    this.newTaskAction = false;
    this.addEditTask = task;
    this.modalHeadingText = 'Edit Task';
    this.actionbuttonText = 'Update';
  }
}
