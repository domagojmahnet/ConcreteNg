import { Component, Inject, OnInit, Optional } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { PricingListItem } from '../../../models/pricing-list-item';
import { EmployerService } from '../../employer-service.service';

@Component({
  selector: 'app-add-edit-pricing-list-item',
  templateUrl: './add-edit-pricing-list-item.component.html',
  styleUrls: ['./add-edit-pricing-list-item.component.less']
})
export class AddEditPricingListItemComponent implements OnInit {

    form = this.formBuilder.group({
        pricingListItemName: [],
        unitOfMeasurement: [],
        price: []
    });

    constructor(
        @Optional() @Inject(MAT_DIALOG_DATA) public data: {pricingListItem: PricingListItem},
        private formBuilder: FormBuilder,
        private employerService: EmployerService
    ) { }

    ngOnInit(): void {
        if(this.data){
            this.form = this.formBuilder.group({
                pricingListItemName: [this.data.pricingListItem.pricingListItemName],
                unitOfMeasurement: [this.data.pricingListItem.unitOfMeasurement],
                price: [this.data.pricingListItem.price]
            });
        }
    }

    saveChanges(){
        let pricingListItem: PricingListItem = {
            pricingListItemId: this.data.pricingListItem === undefined ? -1 : this.data.pricingListItem.pricingListItemId,
            pricingListItemName: this.form.get("pricingListItemName")?.value,
            unitOfMeasurement: this.form.get("unitOfMeasurement")?.value,
            price: this.form.get("price")?.value,
        }
        this.employerService.createOrUpdatePricingListItem(pricingListItem).subscribe(() => {
            
        })
    }

}
