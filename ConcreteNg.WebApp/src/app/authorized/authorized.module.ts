import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SidenavComponent } from './sidenav/sidenav.component';
import { SharedModule } from '../shared.module';
import { RouterModule } from '@angular/router';
import { ProjectCardComponent } from './projects/project-card/project-card.component';
import { NumberCardComponent } from './number-card/number-card.component';
import { EmployerOverviewComponent } from './employer-overview/employer-overview.component';
import { BaseContainerComponent } from './base-container/base-container.component';
import { ProjectDetailsComponent } from './projects/project-details/project-details/project-details.component';
import { PartnerListComponent } from './partners/partner-list/partner-list.component';
import { ProjectListComponent } from './projects/project-list/project-list.component';
import { ProjectOverviewComponent } from './projects/project-details/project-overview/project-overview.component';
import { ProjectTasksComponent } from './projects/project-details/project-tasks/project-tasks.component';
import { ProjectTaskComponent } from './projects/project-details/project-tasks/project-task/project-task.component';
import { ProjectTaskItemComponent } from './projects/project-details/project-tasks/project-task-item/project-task-item.component';
import { AddEditProjectTaskItemComponent } from './projects/project-details/project-tasks/project-task-item/add-edit-project-task-item/add-edit-project-task-item.component';
import { PricingListComponent } from './pricing-list/pricing-list.component';
import { AddEditPricingListItemComponent } from './pricing-list/add-edit-pricing-list-item/add-edit-pricing-list-item.component';
import { AddEditProjectTaskComponent } from './projects/project-details/project-tasks/project-task/add-edit-project-task/add-edit-project-task.component';
import { AddExpenseComponent } from './projects/project-details/project-tasks/project-task-item/add-expense/add-expense.component';
import { DiaryComponent } from './projects/project-details/diary/diary.component';
import { AddDiaryItemComponent } from './projects/project-details/diary/add-diary-item/add-diary-item.component';
import { AddEditPartnerComponent } from './partners/partner-list/add-edit-partner/add-edit-partner.component';
import { UserListComponent } from './users/user-list/user-list.component';
import { AddEditUserComponent } from './users/add-edit-user/add-edit-user.component';
import { AddEditProjectComponent } from './projects/add-edit-project/add-edit-project.component';
import { ExpensesComponent } from './projects/project-details/expenses/expenses.component'

@NgModule({
    declarations: [
        SidenavComponent,
        ProjectCardComponent,
        NumberCardComponent,
        EmployerOverviewComponent,
        BaseContainerComponent,
        ProjectDetailsComponent,
        PartnerListComponent,
        ProjectListComponent,
        ProjectOverviewComponent,
        ProjectTasksComponent,
        ProjectTaskComponent,
        ProjectTaskItemComponent,
        AddEditProjectTaskItemComponent,
        PricingListComponent,
        AddEditPricingListItemComponent,
        AddEditProjectTaskComponent,
        AddExpenseComponent,
        DiaryComponent,
        AddDiaryItemComponent,
        AddEditPartnerComponent,
        UserListComponent,
        AddEditUserComponent,
        AddEditProjectComponent,
        ExpensesComponent
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
