import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { DialogPosition, MatDialog } from '@angular/material/dialog';
import { ProjectStatusEnum } from '../../../../../enums/project-status';
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
    @Output() taskChange = new EventEmitter<ProjectTask>();
    progressPercentage: number;

    constructor(
        private projectDetailsService: ProjectDetailsService,
        private dialog: MatDialog
    ) { }

    ngOnInit(): void {
        this.calculateProgress();
    }

    ngOnChanges(changes: SimpleChanges): void {
        this.calculateProgress();
    }

    onChange(item: ProjectTaskItem){
        let index = this.task.projectTaskItems.findIndex(x => x.projectTaskItemId === item.projectTaskItemId)
        this.task.projectTaskItems[index] = item;
        this.calculateProgress();
    }

    onDelete(item: ProjectTaskItem){
        let index = this.task.projectTaskItems.findIndex(x => x.projectTaskItemId === item.projectTaskItemId)
        this.task.projectTaskItems.splice(index, 1);
        this.calculateProgress();
    }

    calculateProgress(){
        this.progressPercentage = Math.floor((this.task.projectTaskItems.filter(p => p.taskItemStatus === ProjectStatusEnum.Completed).length / this.task.projectTaskItems.length) * 100);
    }

    emitChange(){
        this.taskChange.emit(this.task);
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
