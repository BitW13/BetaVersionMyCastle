import { Component, OnInit } from '@angular/core';
import { TaskCard } from './models/taskCard';
import { TaskCategory } from './models/taskCategory';
import { TaskService } from './services/task.service';
import { TaskCategoryService } from './services/task-category.service';
import { Task } from './models/task';

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.scss']
})
export class TaskComponent implements OnInit {
  
  cards: TaskCard[];

  categories: TaskCategory[];

  constructor(private taskService: TaskService, private categoryService: TaskCategoryService) { }

  ngOnInit() {
    this.loadItems();
  }

  loadItems() {
    this.getCards();
    this.getCategories();
  }

  getCategories() {

    this.categoryService.getItems().subscribe(data => this.categories = data);
  }

  getCards() {
    this.taskService.getCards().subscribe(data => this.cards = data);
  }

  addTask() {
    this.taskService.post(new Task()).subscribe(data => this.cards.unshift(data));
  }

  addCategory() {
    this.categoryService.post(new TaskCategory()).subscribe((data) => this.categories.push(data));
  }

  deleteNote(item: TaskCard) {
    this.taskService.delete(item.task).subscribe(data => {
      this.getCards();
    });
  }

  deleteCategory(item: TaskCategory) {
    this.categoryService.delete(item).subscribe(data => {
      this.loadItems();
    });
  }
}
