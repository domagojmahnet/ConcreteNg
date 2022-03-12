import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Project } from '../../../../models/project';

@Component({
  selector: 'app-project-overview',
  templateUrl: './project-overview.component.html',
  styleUrls: ['./project-overview.component.less']
})
export class ProjectOverviewComponent implements OnInit {

    @Input() project: Project;
    @Output() projectChange = new EventEmitter<Project>();
    
    constructor() { }

    ngOnInit(): void {
    }

}
