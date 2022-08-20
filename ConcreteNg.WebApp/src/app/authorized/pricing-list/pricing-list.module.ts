import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PricingListRoutingModule } from './pricing-list-routing.module';
import { SharedModule } from '../../shared.module';
import { AddEditPricingListItemComponent } from './add-edit-pricing-list-item/add-edit-pricing-list-item.component';
import { PricingListComponent } from './pricing-list.component';


@NgModule({
    declarations: [
        AddEditPricingListItemComponent,
        PricingListComponent
    ],
    imports: [
        CommonModule,
        SharedModule,
        PricingListRoutingModule
    ]
})
export class PricingListModule { }
