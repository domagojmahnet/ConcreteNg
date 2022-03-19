import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ProjectStatusEnum } from '../../../../../enums/project-status';
import { ProjectTaskItem } from '../../../../../models/project-task';
import { ProjectDetailsService } from '../../project-details.service';

@Component({
  selector: 'app-project-task-item',
  templateUrl: './project-task-item.component.html',
  styleUrls: ['./project-task-item.component.less']
})
export class ProjectTaskItemComponent implements OnInit {

    @Input() projectTaskItem: ProjectTaskItem
    @Output() changed = new EventEmitter<ProjectTaskItem>();
    @Output() deleted = new EventEmitter<ProjectTaskItem>();
    projectStatusEnum = ProjectStatusEnum;
    constructor(private projectDetailsService: ProjectDetailsService) { }

    ngOnInit(): void {
        
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
        this.projectDetailsService.deleteProjectTaskItem(this.projectTaskItem).subscribe((data) => {
            this.deleted.emit(this.projectTaskItem);
        })
    }
}
