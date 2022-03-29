import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditProjectTaskItemComponent } from './add-edit-project-task-item.component';

describe('AddEditProjectTaskItemComponent', () => {
  let component: AddEditProjectTaskItemComponent;
  let fixture: ComponentFixture<AddEditProjectTaskItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditProjectTaskItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditProjectTaskItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
