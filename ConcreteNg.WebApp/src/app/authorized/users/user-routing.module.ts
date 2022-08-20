import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserTypeEnum } from '../../enums/user-type';
import { UserListComponent } from './user-list/user-list.component';

const routes: Routes = [
    { path: '', component: UserListComponent, data: {role: UserTypeEnum.Administrator}}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
