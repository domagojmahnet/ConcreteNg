import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EmployerRoutingModule } from './employer-routing.module';
import { SharedModule } from '../../shared.module';
import { NumberCardComponent } from '../number-card/number-card.component';
import { EmployerOverviewComponent } from './employer-overview.component';
import { ProjectCardComponent } from '../projects/project-card/project-card.component';


@NgModule({
    declarations: [
        EmployerOverviewComponent,
        NumberCardComponent,
        ProjectCardComponent,
    ],
    imports: [
        CommonModule,
        SharedModule,
        EmployerRoutingModule
    ]
})
export class EmployerModule { }
