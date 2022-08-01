import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { DialogPosition, MatDialog } from '@angular/material/dialog';
import { ProjectStatusEnum } from '../../../../../enums/project-status';
import { ProjectTaskItem } from '../../../../../models/project-task';
import { ProjectDetailsService } from '../../project-details.service';
import { AddEditProjectTaskItemComponent } from './add-edit-project-task-item/add-edit-project-task-item.component';
import { AddExpenseComponent } from './add-expense/add-expense.component';

@Component({
  selector: 'app-project-task-item',
  templateUrl: './project-task-item.component.html',
  styleUrls: ['./project-task-item.component.less']
})
export class ProjectTaskItemComponent implements OnInit {

    @Input() projectTaskItem: ProjectTaskItem
    @Input() projectTaskId: number;
    @Output() changed = new EventEmitter<ProjectTaskItem>();
    @Output() deleted = new EventEmitter<ProjectTaskItem>();
    projectStatusEnum = ProjectStatusEnum;

    constructor(
        private projectDetailsService: ProjectDetailsService,
        public dialog: MatDialog
    ) { }

    ngOnInit(): void {
        this.projectTaskItem
    }

    updateTaskStatus(){
        let updatedProjectTaskItem = this.projectTaskItem;
        switch(this.projectTaskItem.taskItemStatus){
            case ProjectStatusEnum['To Do']:
                updatedProjectTaskItem.taskItemStatus = ProjectStatusEnum['In Progress'];
                updatedProjectTaskItem.startTime = new Date;
                break;
            case ProjectStatusEnum['In Progress']:
                updatedProjectTaskItem.taskItemStatus = ProjectStatusEnum.Completed;
                updatedProjectTaskItem.finishTime = new Date;
                break;
            case ProjectStatusEnum.Completed:
                updatedProjectTaskItem.taskItemStatus = ProjectStatusEnum['In Progress'];
                updatedProjectTaskItem.finishTime = undefined;
                break;
        }
        this.projectDetailsService.updateProjectTaskItem(updatedProjectTaskItem).subscribe((data) => {
            this.projectTaskItem = updatedProjectTaskItem;
            this.changed.emit(this.projectTaskItem);
        })
    }

    deleteTask(){
        this.projectDetailsService.deleteProjectTaskItem(this.projectTaskItem.projectTaskItemId, this.projectTaskId);
    }

    OpenAddEditItemDialog(){
        const dialogPosition: DialogPosition = {
            right: 0 + 'px',
        }
          
        const dialogRef = this.dialog.open(AddEditProjectTaskItemComponent, {
            width: '450px',
            height: '100%',
            position: dialogPosition,
            data: {projectTaskItem: this.projectTaskItem, projectTaskId: this.projectTaskId}
        });
    }

    OpenAddExpenseDialog(){
        const dialogPosition: DialogPosition = {
            right: 0 + 'px',
        }
          
        const dialogRef = this.dialog.open(AddExpenseComponent, {
            width: '450px',
            height: '100%',
            position: dialogPosition,
            data: {projectTaskItemId: this.projectTaskItem.projectTaskItemId, unitOfMeasurement: this.projectTaskItem.pricingListItem.unitOfMeasurement, pricingListItemId: this.projectTaskItem.pricingListItem.pricingListItemId}
        });
    }
}
