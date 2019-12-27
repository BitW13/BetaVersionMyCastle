import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FileCategoryItemComponent } from './file-category-item.component';

describe('FileCategoryItemComponent', () => {
  let component: FileCategoryItemComponent;
  let fixture: ComponentFixture<FileCategoryItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FileCategoryItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FileCategoryItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
