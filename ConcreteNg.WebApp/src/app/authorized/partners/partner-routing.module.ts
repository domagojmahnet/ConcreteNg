import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '../../auth.guard';
import { BaseContainerComponent } from '../base-container/base-container.component';
import { EmployerOverviewComponent } from '../employer-overview/employer-overview.component';
import { PartnerListComponent } from './partner-list/partner-list.component';

const routes: Routes = [
    { path: '', component: PartnerListComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: [AuthGuard]
})
export class PartnerRoutingModule { }
