import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SidenavComponent } from './sidenav/sidenav.component';
import { SharedModule } from '../shared.module';
import { BaseContainerComponent } from './base-container/base-container.component';
import { AuthorizedRoutingModule } from './authorized-routing.module';

@NgModule({
    declarations: [
        SidenavComponent,
        BaseContainerComponent,
    ],
    imports: [
        CommonModule,
        AuthorizedRoutingModule,
        SharedModule
    ],
    exports: [
        SidenavComponent
    ],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
    })
export class AuthorizedModule { }
