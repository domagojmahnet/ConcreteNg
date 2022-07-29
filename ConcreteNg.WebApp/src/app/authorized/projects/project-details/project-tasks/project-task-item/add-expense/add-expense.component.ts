import { Component, Inject, OnInit, Optional } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ExpenseTypeEnum } from '../../../../../../enums/expense-type-enum';
import { ProjectDetailsService } from '../../../project-details.service';

@Component({
  selector: 'app-add-expense',
  templateUrl: './add-expense.component.html',
  styleUrls: ['./add-expense.component.less']
})
export class AddExpenseComponent implements OnInit {

    selectedType: ExpenseTypeEnum;

    public get expenseTypeEnum(): typeof ExpenseTypeEnum {
        return ExpenseTypeEnum; 
    }

    form = this.formBuilder.group({
        totalCost: [],
        partner: [],
        quantity: [],
    });

    constructor(
        @Optional() @Inject(MAT_DIALOG_DATA) public data: {projectTaskItemId: number, unitOfMeasurement: string},
        private projectDetailsService: ProjectDetailsService,
        private formBuilder: FormBuilder
    ) { }

    ngOnInit(): void {
    }

}
