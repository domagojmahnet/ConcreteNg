import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { DialogPosition, MatDialog } from '@angular/material/dialog';
import { AccountService } from '../../../../../account.service';
import { ProjectStatusEnum } from '../../../../../enums/project-status';
import { UserTypeEnum } from '../../../../../enums/user-type';
import { Project } from '../../../../../models/project';
import { ProjectTask, ProjectTaskItem } from '../../../../../models/project-task';
import { ProjectDetailsService } from '../../project-details.service';
import { AddEditProjectTaskItemComponent } from '../project-task-item/add-edit-project-task-item/add-edit-project-task-item.component';

@Component({
  selector: 'app-project-task',
  templateUrl: './project-task.component.html',
  styleUrls: ['./project-task.component.less']
})
export class ProjectTaskComponent implements OnInit, OnChanges {

    @Input() task: ProjectTask;
    @Input() project: Project;
    @Output() taskChange = new EventEmitter<ProjectTask>();
    progressPercentage: number;
    userRole: UserTypeEnum | undefined;

    public get userTypeEnum(): typeof UserTypeEnum {
        return UserTypeEnum; 
    }
    constructor(
        private projectDetailsService: ProjectDetailsService,
        private dialog: MatDialog,
        private accountService: AccountService
    ) { }

    ngOnInit(): void {
        this.userRole = this.accountService.userValue?.userType;
        this.calculateProgress();
        this.projectDetailsService.taskChange.subscribe(() => {
            this.calculateProgress();
        })
    }

    ngOnChanges(changes: SimpleChanges): void {
        this.calculateProgress();
    }

    
    calculateProgress(){
        this.progressPercentage = Math.floor((this.task.projectTaskItems.filter(p => p.taskItemStatus === ProjectStatusEnum.Completed).length / this.task.projectTaskItems.length) * 100);
    }

    deleteProjectTask(){
        this.projectDetailsService.deleteProjectTask(this.task.projectTaskId);
    }

    OpenAddEditItemDialog(projectTaskItem?: ProjectTaskItem){
        const dialogPosition: DialogPosition = {
            right: 0 + 'px',
          }
          
        const dialogRef = this.dialog.open(AddEditProjectTaskItemComponent, {
            width: '450px',
            height: '100%',
            position: dialogPosition,
            data: {projectTaskItem: projectTaskItem, projectTaskId: this.task.projectTaskId}
        });
    }
}
