import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingPageComponent } from './unauthorized/landing-page/landing-page.component';
import { LoginComponent } from './unauthorized/login/login.component';
import { EmployerOverviewComponent } from './authorized/employer-overview/employer-overview.component';
import { BaseContainerComponent } from './authorized/base-container/base-container.component';


const routes: Routes = [
    { path: 'login', component: LoginComponent },
    { path: 'home', component: LandingPageComponent },
    { path: 'authorized', component: BaseContainerComponent,
        children: [
            {
                path: 'employer-overview',
                component: EmployerOverviewComponent,
            },
            { path: '',   redirectTo: 'employer-overview', pathMatch: 'full'}
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
