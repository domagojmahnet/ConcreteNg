import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddDiaryItemComponent } from './add-diary-item.component';

describe('AddDiaryItemComponent', () => {
  let component: AddDiaryItemComponent;
  let fixture: ComponentFixture<AddDiaryItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddDiaryItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddDiaryItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
