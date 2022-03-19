import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { Project } from '../../../../models/project';
import { ProjectTask } from '../../../../models/project-task';
import { ProjectDetailsService } from '../project-details.service';

@Component({
  selector: 'app-project-tasks',
  templateUrl: './project-tasks.component.html',
  styleUrls: ['./project-tasks.component.less']
})
export class ProjectTasksComponent implements OnInit, OnChanges {

    @Input() project: Project;
    @Output() projectChange = new EventEmitter<Project>();

    projectTasks: ProjectTask[];

    constructor(
        private projectService: ProjectDetailsService,
    ) { }

    ngOnInit(): void {
        this.projectService.getProjectTasks(this.project.projectId).subscribe((data) => {
            this.projectTasks = data
        });
    }

    ngOnChanges(changes: SimpleChanges) {

    }

    update(){
        this.project.name = "bla";
        this.projectChange.emit(this.project)
    }

}
