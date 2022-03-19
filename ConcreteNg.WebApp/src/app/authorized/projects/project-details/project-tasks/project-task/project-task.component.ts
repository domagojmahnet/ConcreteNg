import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { ProjectStatusEnum } from '../../../../../enums/project-status';
import { ProjectTask, ProjectTaskItem } from '../../../../../models/project-task';

@Component({
  selector: 'app-project-task',
  templateUrl: './project-task.component.html',
  styleUrls: ['./project-task.component.less']
})
export class ProjectTaskComponent implements OnInit, OnChanges {

    @Input() task: ProjectTask
    progressPercentage: number;

    constructor() { }

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

}
