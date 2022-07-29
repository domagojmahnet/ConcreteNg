import { Component, OnInit } from '@angular/core';
import { Project } from '../../models/project';
import { ProjectService } from '../projects/services/project.service';

@Component({
  selector: 'app-employer-overview',
  templateUrl: './employer-overview.component.html',
  styleUrls: ['./employer-overview.component.less']
})
export class EmployerOverviewComponent implements OnInit {

    public activeProjects: Project[];
    public numberOfActiveProjects: number;
    public overdueProjects: number;
    public overrunProjects: number;
    constructor(private projectService: ProjectService) { }

    ngOnInit(): void {
        this.projectService.getBaseProjects().subscribe((data: Project[]) => {
            this.activeProjects = data;
            this.numberOfActiveProjects = data.length;
            let today = new Date();
            this.overdueProjects = data.filter(x => x.expectedEndDate < today).length;
            this.overrunProjects = data.filter(x => x.currentCost > x.expectedCost).length;
        })
    }
}
