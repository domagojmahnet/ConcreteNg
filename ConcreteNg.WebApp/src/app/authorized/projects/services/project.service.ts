import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { environment } from '../../../../environments/environment';
import { AccountService } from '../../../account.service';
import { ProjectStatusEnum } from '../../../enums/project-status';
import { CostOverview } from '../../../models/cost-everview';
import { DiaryItem } from '../../../models/diary-item';
import { GraphData } from '../../../models/graph-models/graph-data';
import { Project } from '../../../models/project';
import { TableRequest } from '../../../models/table-request';
import { User } from '../../../models/user';

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

    AddEditProject(project: Project, managerId: number){
        return this.http.post<any>(this.projectApiUrl + "/project/" + managerId, project);
    }

    getEligibleManagers(){
        return this.http.get<User[]>(this.projectApiUrl + "/managers");
    }

    getCostOverview(projectId: number){
        return this.http.get<CostOverview[]>(this.projectApiUrl + "/costOverview/" + projectId);
    }

    getProjectGraphData(projectId: number){
        return this.http.get<GraphData>(this.projectApiUrl + "/graphData/" + projectId);
    }

    updateProjectStatus(projectStatus: ProjectStatusEnum, projectId: number){
        return this.http.post<any>(this.projectApiUrl + "/updateStatus/" + projectId, projectStatus);
    }

    getManager(projectId: number){
        return this.http.get<User>(this.projectApiUrl + "/manager/" + projectId);
    }
}
