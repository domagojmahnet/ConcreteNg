import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ProjectTaskItem } from '../../../../../../models/project-task';

@Component({
  selector: 'app-add-edit-project-task-item',
  templateUrl: './add-edit-project-task-item.component.html',
  styleUrls: ['./add-edit-project-task-item.component.less']
})
export class AddEditProjectTaskItemComponent implements OnInit {

    form = this.formBuilder.group({
        name: [this.data.projectTaskItem.projectTaskItemName],
        startDate: [this.data.projectTaskItem.startTime],
        finishDate: [this.data.projectTaskItem.finishTime]
    });

    constructor(
        @Inject(MAT_DIALOG_DATA) public data: {projectTaskItem: ProjectTaskItem},
        private formBuilder: FormBuilder
    ) { }

    ngOnInit(): void {
        this.data.projectTaskItem.projectTaskItemName
        debugger;
    }

}
