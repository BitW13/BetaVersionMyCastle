import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FileAccessItemComponent } from './file-access-item.component';

describe('FileAccessItemComponent', () => {
  let component: FileAccessItemComponent;
  let fixture: ComponentFixture<FileAccessItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FileAccessItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FileAccessItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
