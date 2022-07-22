import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditPricingListItemComponent } from './add-edit-pricing-list-item.component';

describe('AddEditPricingListItemComponent', () => {
  let component: AddEditPricingListItemComponent;
  let fixture: ComponentFixture<AddEditPricingListItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditPricingListItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditPricingListItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
