import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UnauthorizedModule } from './unauthorized/unauthorized.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NavComponent } from './nav/nav.component';
import { ToastrModule } from 'ngx-toastr';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AngularMaterialModule } from './angular-material.module';
import { FlexLayoutModule } from '@angular/flex-layout';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from './shared.module';

@NgModule({
    declarations: [
        AppComponent,
        NavComponent
    ],
    imports: [
        SharedModule,
        ToastrModule.forRoot(),
        UnauthorizedModule,
    ],
        providers: [],
        bootstrap: [AppComponent],
        schemas: [CUSTOM_ELEMENTS_SCHEMA]
    })
export class AppModule { }
