import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PartnerRoutingModule } from './partner-routing.module';
import { AddEditPartnerComponent } from './partner-list/add-edit-partner/add-edit-partner.component';
import { PartnerListComponent } from './partner-list/partner-list.component';
import { SharedModule } from '../../shared.module';


@NgModule({
    declarations: [
        PartnerListComponent,
        AddEditPartnerComponent,
    ],
    imports: [
        CommonModule,
        SharedModule,
        PartnerRoutingModule,
    ],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class PartnerModule { }
