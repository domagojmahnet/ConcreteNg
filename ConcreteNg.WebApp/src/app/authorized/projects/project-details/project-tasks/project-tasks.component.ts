import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { DialogPosition, MatDialog } from '@angular/material/dialog';
import { AccountService } from '../../../../account.service';
import { UserTypeEnum } from '../../../../enums/user-type';
import { Project } from '../../../../models/project';
import { ProjectTask } from '../../../../models/project-task';
import { ProjectDetailsService } from '../project-details.service';
import { AddEditProjectTaskComponent } from './project-task/add-edit-project-task/add-edit-project-task.component';

@Component({
  selector: 'app-project-tasks',
  templateUrl: './project-tasks.component.html',
  styleUrls: ['./project-tasks.component.less']
})
export class ProjectTasksComponent implements OnInit, OnChanges {

    @Input() project: Project;
    @Output() projectChange = new EventEmitter<Project>();
    
    projectTasks: ProjectTask[];
    userRole: UserTypeEnum | undefined;

    public get userTypeEnum(): typeof UserTypeEnum {
        return UserTypeEnum; 
    }
    constructor(
        private projectDetailsService: ProjectDetailsService,
        public dialog: MatDialog,
        private accountService: AccountService
    ) { }

    ngOnInit(): void {
        this.userRole = this.accountService.userValue?.userType;
        this.projectDetailsService.taskChange.subscribe((res) => {
            this.projectTasks = this.projectDetailsService.projectTasks;
        });
        this.projectDetailsService.getProjectTasks(this.project.projectId);
    }

    ngOnChanges(changes: SimpleChanges) {

    }

    update(){
        this.project.name = "bla";
        this.projectChange.emit(this.project)
    }

    OpenAddEditItemDialog(projectTask?: ProjectTask){
        const dialogPosition: DialogPosition = {
            right: 0 + 'px',
        }
          
        const dialogRef = this.dialog.open(AddEditProjectTaskComponent, {
            width: '450px',
            height: '100%',
            position: dialogPosition,
            data: {projectTask: projectTask, projectId: this.project.projectId}
        });

        dialogRef.afterClosed().subscribe(result => {
            if(result){
                
            }
        });
    }

}
