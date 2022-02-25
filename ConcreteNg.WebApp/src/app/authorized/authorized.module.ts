import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProjectOverviewComponent } from './projects/project-overview/project-overview.component';
import { SidenavComponent } from './sidenav/sidenav.component';
import { SharedModule } from '../shared.module';
import { RouterModule } from '@angular/router';
import { ActiveProjectsComponent } from './projects/active-projects/active-projects.component';
import { ProjectCardComponent } from './projects/project-card/project-card.component';

@NgModule({
    declarations: [
        ProjectOverviewComponent,
        SidenavComponent,
        ActiveProjectsComponent,
        ProjectCardComponent
    ],
    imports: [
        CommonModule,
        SharedModule
    ],
    exports: [
        SidenavComponent,
        ProjectCardComponent
    ],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
    })
export class AuthorizedModule { }
