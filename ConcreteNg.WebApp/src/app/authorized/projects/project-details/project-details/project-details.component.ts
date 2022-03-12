import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Project } from '../../../../models/project';
import { ProjectService } from '../../services/project.service';
import { ProjectDetailsService } from '../project-details.service';

@Component({
  selector: 'app-project-details',
  templateUrl: './project-details.component.html',
  styleUrls: ['./project-details.component.less']
})
export class ProjectDetailsComponent implements OnInit {

    project: Project;

    constructor(
        private projectService: ProjectDetailsService,
        private route: ActivatedRoute
    ) { }

    ngOnInit(): void {
        this.projectService.getProjectDetails(Number(this.route.snapshot.paramMap.get('id'))).subscribe((data) => {
            this.project = data;
        });
    }
}
