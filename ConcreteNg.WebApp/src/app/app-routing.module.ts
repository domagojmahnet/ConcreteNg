import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingPageComponent } from './unauthorized/landing-page/landing-page.component';
import { LoginComponent } from './unauthorized/login/login.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'home', component: LandingPageComponent },
  { path: '**', component: LandingPageComponent },
  { path: '',   redirectTo: '**', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
