import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { environment } from '../../../../environments/environment';
import { AccountService } from '../../../account.service';
import { DiaryItem } from '../../../models/diary-item';
import { Project } from '../../../models/project';
import { TableRequest } from '../../../models/table-request';

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

    getBaseProjects() {
        return this.http.get<Project[]>(this.projectApiUrl);
    }

    getProjectDetails(id: number){
        return this.http.get<Project>(this.projectApiUrl + "/" + id);
    }

    getProjectsTable(tableRequest: TableRequest){
        return this.http.post<any>(this.projectApiUrl + "/allProjects", tableRequest);
    }

    getDiaryItems(tableRequest: TableRequest, projectId: number){
        return this.http.post<any>(this.projectApiUrl + "/diaryItems/" + projectId, tableRequest);
    }

    addDIaryItem(diaryItem: DiaryItem, projectId: number){
        return this.http.post<any>(this.projectApiUrl + "/diaryItem/" + projectId, diaryItem);
    }
}
