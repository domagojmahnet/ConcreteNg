import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { environment } from '../../../../environments/environment';
import { AccountService } from '../../../account.service';
import { Project } from '../../../models/project';

@Injectable({
  providedIn: 'root'
})
export class ProjectService {

    constructor(
        private http: HttpClient, 
            private toastr: ToastrService,
            private router: Router,
            private accountService: AccountService
    ) { }

    projectApiUrl: string = environment.BASE_URL+ "api/Project";

    getProjects() {
        return this.http.get<Project[]>(this.projectApiUrl);
    }
}
