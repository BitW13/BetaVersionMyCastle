import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TaskSeverityComponent } from './task-severity.component';

describe('TaskSeverityComponent', () => {
  let component: TaskSeverityComponent;
  let fixture: ComponentFixture<TaskSeverityComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TaskSeverityComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TaskSeverityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
