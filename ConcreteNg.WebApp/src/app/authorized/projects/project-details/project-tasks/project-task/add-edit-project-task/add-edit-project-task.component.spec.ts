import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditProjectTaskComponent } from './add-edit-project-task.component';

describe('AddEditProjectTaskComponent', () => {
  let component: AddEditProjectTaskComponent;
  let fixture: ComponentFixture<AddEditProjectTaskComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditProjectTaskComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditProjectTaskComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
