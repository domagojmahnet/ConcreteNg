import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserTypeEnum } from '../enums/user-type';
import { BaseContainerComponent } from './base-container/base-container.component';
import { EmployerOverviewComponent } from './employer-overview/employer-overview.component';
import { PartnerListComponent } from './partners/partner-list/partner-list.component';
import { UserListComponent } from './users/user-list/user-list.component';


const routes: Routes = [
    { path: '', redirectTo: 'employer-overview'},
    { path: 'employer-overview', loadChildren: () => import('./employer-overview/employer.module').then(m => m.EmployerModule) },
    { path: 'project-details/:id', loadChildren: () => import('./projects/project-details/project-detail.module').then(m => m.ProjectDetailModule) },
    { path: 'pricing-list', loadChildren: () => import('./pricing-list/pricing-list.module').then(m => m.PricingListModule) },
    { path: 'partners', loadChildren: () => import('./partners/partner.module').then(m => m.PartnerModule)},
    { path: 'projects', loadChildren: () => import('./projects/projects.module').then(m => m.ProjectsModule)},
    { path: 'employees', loadChildren: () => import('./users/user.module').then(m => m.UserModule)}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AuthorizedRoutingModule { }
