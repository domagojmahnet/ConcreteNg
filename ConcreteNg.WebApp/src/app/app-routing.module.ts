import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingPageComponent } from './unauthorized/landing-page/landing-page.component';
import { LoginComponent } from './unauthorized/login/login.component';
import { ProjectOverviewComponent } from './authorized/projects/project-overview/project-overview.component';
import { ActiveProjectsComponent } from './authorized/projects/active-projects/active-projects.component';


const routes: Routes = [
    { path: 'login', component: LoginComponent },
    { path: 'home', component: LandingPageComponent },
    { path: 'project-overview', component: ProjectOverviewComponent,
        children: [
            {
                path: 'active-projects',
                component: ActiveProjectsComponent,
            },
            { path: '',   redirectTo: 'active-projects', pathMatch: 'full'}
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
