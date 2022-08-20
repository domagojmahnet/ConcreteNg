import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProjectsRoutingModule } from './projects-routing.module';
import { ProjectListComponent } from './project-list/project-list.component';
import { AddEditProjectComponent } from './add-edit-project/add-edit-project.component';
import { SharedModule } from '../../shared.module';


@NgModule({
    declarations: [
        ProjectListComponent,
        AddEditProjectComponent,
    ],
    imports: [
        CommonModule,
        SharedModule,
        ProjectsRoutingModule
    ],
})
export class ProjectsModule { }
