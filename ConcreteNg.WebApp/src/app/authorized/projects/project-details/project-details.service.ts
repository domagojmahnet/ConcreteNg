import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { Project } from '../../../models/project';
import { ProjectTask, ProjectTaskItem } from '../../../models/project-task';

@Injectable({
  providedIn: 'root'
})
export class ProjectDetailsService {

    constructor(private http: HttpClient) {}

    projectApiUrl: string = environment.BASE_URL+ "api/Project";
    projectTaskApiUrl: string = environment.BASE_URL+ "api/ProjectTask";

    getProjectDetails(id: number) {
        return this.http.get<Project>(this.projectApiUrl + "/" + id);
    }

    getProjectTasks(id: number){
        return this.http.get<ProjectTask[]>(this.projectTaskApiUrl + "/" + id);
    }

    updateProjectTaskItem(projectTaskItem: ProjectTaskItem){
        return this.http.post<ProjectTask>(this.projectTaskApiUrl + "/updateItem", projectTaskItem);
    }

    deleteProjectTaskItem(projectTaskItem: ProjectTaskItem){
        return this.http.post<ProjectTask>(this.projectTaskApiUrl + "/deleteItem", projectTaskItem);
    }

    createOrUpdateProjectTask(task: ProjectTask, projectId: number){
        return this.http.post<any>(this.projectTaskApiUrl + "/projectTask/" + projectId, task);
    }


}
