import { Component, Inject, OnInit, Optional } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ExpenseTypeEnum } from '../../../../../../enums/expense-type-enum';
import { Expense } from '../../../../../../models/expense';
import { Partner } from '../../../../../../models/partner';
import { EmployerService } from '../../../../../employer-service.service';
import { ProjectDetailsService } from '../../../project-details.service';

@Component({
  selector: 'app-add-expense',
  templateUrl: './add-expense.component.html',
  styleUrls: ['./add-expense.component.less']
})
export class AddExpenseComponent implements OnInit {

    partnerList: Partner[];
    searchedPartnerList: Partner[];
    selectedType: ExpenseTypeEnum;

    public get expenseTypeEnum(): typeof ExpenseTypeEnum {
        return ExpenseTypeEnum; 
    }

    form = this.formBuilder.group({
        totalCost: [''],
        partner: [''],
        quantity: [''],
    });

    constructor(
        @Optional() @Inject(MAT_DIALOG_DATA) public data: {projectTaskItemId: number, unitOfMeasurement: string, pricingListItemId: number},
        private projectDetailsService: ProjectDetailsService,
        private employerService: EmployerService,
        private formBuilder: FormBuilder
    ) { }

    ngOnInit(): void {
        this.employerService.getPartners().subscribe((res) => {
            this.partnerList = res;
            this.searchedPartnerList = res;
            debugger;
        })
    }

    saveChanges(){
        switch(this.selectedType){
            case this.expenseTypeEnum.Labour:
                this.form.get('quantity')?.setValidators([Validators.required]);
                this.form.get('quantity')?.updateValueAndValidity();
                this.form.get('totalCost')?.clearValidators();
                this.form.get('totalCost')?.updateValueAndValidity();
                this.form.get('partner')?.clearValidators();
                this.form.get('partner')?.updateValueAndValidity();
                break;
            case this.expenseTypeEnum.Material:
                this.form.get('partner')?.clearValidators();
                this.form.get('partner')?.updateValueAndValidity();
                this.form.get('quantity')?.clearValidators();
                this.form.get('quantity')?.updateValueAndValidity();
                this.form.get('totalCost')?.setValidators([Validators.required]);
                this.form.get('totalCost')?.updateValueAndValidity();
                break;
            case this.expenseTypeEnum.Partner:
                this.form.get('quantity')?.clearValidators();
                this.form.get('quantity')?.updateValueAndValidity();
                this.form.get('totalCost')?.setValidators([Validators.required]);
                this.form.get('totalCost')?.updateValueAndValidity();
                this.form.get('partner')?.setValidators([Validators.required]);
                this.form.get('partner')?.updateValueAndValidity();
                break;
        }
        debugger;
        if(this.form.valid){
            let expense: Expense = {
                expenseId: -1,
                expenseType: this.selectedType
            };
            this.selectedType === this.expenseTypeEnum.Labour ? expense.quantity = this.form.get("quantity")?.value : expense.totalCost = this.form.get("totalCost")?.value;
            this.selectedType === this.expenseTypeEnum.Partner ? 
                this.projectDetailsService.addExpense(expense, this.data.projectTaskItemId, this.data.pricingListItemId, this.form.get("partner")?.value)
                : this.projectDetailsService.addExpense(expense, this.data.projectTaskItemId, this.data.pricingListItemId);
        }
    }
        
    onKey(value: string) { 
        this.searchedPartnerList = this.search(value);
    }

    search(value: string) { 
        let filter = value.toLowerCase();
        return this.partnerList.filter(x => x.name.toLowerCase().includes(filter.toLowerCase()));
    }
}
