import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployerOverviewComponent } from './employer-overview.component';

const routes: Routes = [
    { path: '', component: EmployerOverviewComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EmployerRoutingModule { }
