import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { LandingPageComponent } from './landing-page/landing-page.component';
import { SharedModule } from '../shared.module';

@NgModule({
    declarations: [
        LoginComponent,
        LandingPageComponent
    ],
    imports: [
        CommonModule,
        SharedModule
    ],
    exports:[
    ],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class UnauthorizedModule { }
