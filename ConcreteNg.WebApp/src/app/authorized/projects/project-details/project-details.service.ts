import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { environment } from '../../../../environments/environment';
import { Project } from '../../../models/project';

@Injectable({
  providedIn: 'root'
})
export class ProjectDetailsService {

    constructor(private http: HttpClient) {}

    projectApiUrl: string = environment.BASE_URL+ "api/Project";

    getProjectDetails(id: number) {
        return this.http.get<Project>(this.projectApiUrl + "/" + id);
    }

}
