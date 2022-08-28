import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProjectDetailRoutingModule } from './project-detail-routing.module';
import { AddDiaryItemComponent } from './diary/add-diary-item/add-diary-item.component';
import { DiaryComponent } from './diary/diary.component';
import { ExpensesComponent } from './expenses/expenses.component';
import { ProjectDetailsComponent } from './project-details/project-details.component';
import { ProjectOverviewComponent } from './project-overview/project-overview.component';
import { AddEditProjectTaskItemComponent } from './project-tasks/project-task-item/add-edit-project-task-item/add-edit-project-task-item.component';
import { AddExpenseComponent } from './project-tasks/project-task-item/add-expense/add-expense.component';
import { ProjectTaskItemComponent } from './project-tasks/project-task-item/project-task-item.component';
import { AddEditProjectTaskComponent } from './project-tasks/project-task/add-edit-project-task/add-edit-project-task.component';
import { ProjectTaskComponent } from './project-tasks/project-task/project-task.component';
import { ProjectTasksComponent } from './project-tasks/project-tasks.component';
import { SharedModule } from '../../../shared.module';
import { DocumentsComponent } from './documents/documents.component';


@NgModule({
    declarations: [
        ProjectDetailsComponent,
        ProjectOverviewComponent,
        ProjectTasksComponent,
        ProjectTaskComponent,
        ProjectTaskItemComponent,
        AddEditProjectTaskItemComponent,
        AddEditProjectTaskComponent,
        AddExpenseComponent,
        DiaryComponent,
        AddDiaryItemComponent,
        ExpensesComponent,
        DocumentsComponent
    ],
    imports: [
        CommonModule,
        SharedModule,
        ProjectDetailRoutingModule,
    ]
})
export class ProjectDetailModule { }
