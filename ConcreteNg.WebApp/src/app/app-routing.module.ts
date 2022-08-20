import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingPageComponent } from './unauthorized/landing-page/landing-page.component';
import { LoginComponent } from './unauthorized/login/login.component';
import { EmployerOverviewComponent } from './authorized/employer-overview/employer-overview.component';
import { BaseContainerComponent } from './authorized/base-container/base-container.component';
import { ProjectDetailsComponent } from './authorized/projects/project-details/project-details/project-details.component';
import { PartnerListComponent } from './authorized/partners/partner-list/partner-list.component';
import { ProjectListComponent } from './authorized/projects/project-list/project-list.component';
import { PricingListComponent } from './authorized/pricing-list/pricing-list.component';
import { UserListComponent } from './authorized/users/user-list/user-list.component';
import { AuthGuard } from './auth.guard';
import { UserTypeEnum } from './enums/user-type';


const routes: Routes = [
    { path: 'login', component: LoginComponent },
    { path: 'home', component: LandingPageComponent },
    { path: 'authorized', component:BaseContainerComponent, loadChildren: () => import('./authorized/authorized.module').then(m => m.AuthorizedModule), canActivate: [AuthGuard]},
    { path: '**', component: LandingPageComponent },
    { path: '',   redirectTo: '**', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: [AuthGuard]
})
export class AppRoutingModule { }
