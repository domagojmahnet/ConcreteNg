import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProjectOverviewComponent } from './projects/project-overview/project-overview.component';
import { SidenavComponent } from './sidenav/sidenav.component';
import { SharedModule } from '../shared.module';
import { RouterModule } from '@angular/router';
import { ProjectCardComponent } from './projects/project-card/project-card.component';
import { NumberCardComponent } from './number-card/number-card.component';
import { EmployerOverviewComponent } from './employer-overview/employer-overview.component';
import { BaseContainerComponent } from './base-container/base-container.component';

@NgModule({
    declarations: [
        ProjectOverviewComponent,
        SidenavComponent,
        ProjectCardComponent,
        NumberCardComponent,
        EmployerOverviewComponent,
        BaseContainerComponent
    ],
    imports: [
        CommonModule,
        SharedModule
    ],
    exports: [
        SidenavComponent,
        ProjectCardComponent,
    ],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
    })
export class AuthorizedModule { }
