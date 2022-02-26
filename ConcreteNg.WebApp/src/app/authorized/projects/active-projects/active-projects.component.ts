import { Component, OnInit } from '@angular/core';
import { Project } from '../../../models/project';
import { ProjectService } from '../services/project.service';

@Component({
  selector: 'app-active-projects',
  templateUrl: './active-projects.component.html',
  styleUrls: ['./active-projects.component.less']
})
export class ActiveProjectsComponent implements OnInit {

    public activeProjects: Project[];
    constructor(private projectService: ProjectService) { }

    ngOnInit(): void {
        this.projectService.getProjects().subscribe((data: Project[]) => {
            this.activeProjects = data;
        })
    }

}
