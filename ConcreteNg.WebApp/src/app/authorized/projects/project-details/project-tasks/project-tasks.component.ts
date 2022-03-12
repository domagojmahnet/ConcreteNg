import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Project } from '../../../../models/project';
import { ProjectDetailsService } from '../project-details.service';

@Component({
  selector: 'app-project-tasks',
  templateUrl: './project-tasks.component.html',
  styleUrls: ['./project-tasks.component.less']
})
export class ProjectTasksComponent implements OnInit {

    @Input() project: Project;
    @Output() projectChange = new EventEmitter<Project>();

    constructor(
        private projectService: ProjectDetailsService,
    ) { }

    ngOnInit(): void {

    }

    update(){
        this.project.name = "bla";
        this.projectChange.emit(this.project)
    }

}
