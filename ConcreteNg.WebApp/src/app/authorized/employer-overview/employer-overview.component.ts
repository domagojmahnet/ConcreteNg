import { Component, OnInit } from '@angular/core';
import { ProjectStatusEnum } from '../../enums/project-status';
import { Project } from '../../models/project';
import { ProjectService } from '../projects/services/project.service';

@Component({
  selector: 'app-employer-overview',
  templateUrl: './employer-overview.component.html',
  styleUrls: ['./employer-overview.component.less']
})
export class EmployerOverviewComponent implements OnInit {

    public activeProjects: Project[];
    public toDoProjects: Project[];
    public numberOfActiveProjects: number;
    public overdueProjects: number;
    public overrunProjects: number;
    constructor(private projectService: ProjectService) { }

    ngOnInit(): void {
        this.projectService.getBaseProjects().subscribe((data: Project[]) => {
            this.activeProjects = data.filter(x => x.projectStatus === ProjectStatusEnum['In Progress']);
            this.toDoProjects = data.filter(x => x.projectStatus === ProjectStatusEnum['To Do']);
            this.numberOfActiveProjects = this.activeProjects.length;
            this.overdueProjects = this.activeProjects.filter(x => new Date(x.expectedEndDate) < new Date()).length;
            this.overrunProjects = this.activeProjects.filter(x => x.currentCost >= x.expectedCost).length;
        })
    }
}
