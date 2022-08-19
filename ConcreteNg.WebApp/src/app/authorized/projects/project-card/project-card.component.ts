import { Component, Input, OnInit } from '@angular/core';
import { ProjectStatusEnum } from '../../../enums/project-status';
import { Project } from '../../../models/project';

@Component({
  selector: 'app-project-card',
  templateUrl: './project-card.component.html',
  styleUrls: ['./project-card.component.less']
})
export class ProjectCardComponent implements OnInit {

    @Input() public projectData: Project
    routeLink: any;
    projectStatusEnum = ProjectStatusEnum;
    isGreaterThanToday:  boolean;

    constructor() { }

    ngOnInit(): void {
        this.projectData.name;
        this.routeLink = "../project-details/" + this.projectData.projectId;
        this.isGreaterThanToday =  new Date(this.projectData.expectedEndDate) > new Date();
    }

}
