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


const routes: Routes = [
    { path: 'login', component: LoginComponent },
    { path: 'home', component: LandingPageComponent },
    { path: 'authorized', component: BaseContainerComponent,
        children: [
            {
                path: 'employer-overview',
                component: EmployerOverviewComponent,
            },
            { path: '',   redirectTo: 'employer-overview', pathMatch: 'full'},
            { path: 'project-details/:id', component: ProjectDetailsComponent },
            { path: 'pricing-list', component: PricingListComponent },
            { path: 'partners', component: PartnerListComponent },
            { path: 'projects', component: ProjectListComponent },
        ]
        },
    { path: '**', component: LandingPageComponent },
    { path: '',   redirectTo: '**', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
