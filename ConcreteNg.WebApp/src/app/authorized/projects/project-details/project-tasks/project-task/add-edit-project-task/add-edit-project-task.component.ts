import { Component, EventEmitter, Inject, OnInit, Optional, Output } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ProjectTask } from '../../../../../../models/project-task';
import { ProjectDetailsService } from '../../../project-details.service';

@Component({
  selector: 'app-add-edit-project-task',
  templateUrl: './add-edit-project-task.component.html',
  styleUrls: ['./add-edit-project-task.component.less']
})
export class AddEditProjectTaskComponent implements OnInit {

    form = this.formBuilder.group({
        projectTaskName: []
    });

    constructor(
        @Optional() @Inject(MAT_DIALOG_DATA) public data: {projectTask: ProjectTask, projectId: number},
        private formBuilder: FormBuilder,
        private projectDetailsService: ProjectDetailsService
    ) { }

    ngOnInit(): void {
        if(this.data){
            this.form = this.formBuilder.group({
                projectTaskName: [this.data.projectTask.projectTaskName]
            });
        }
    }

    saveChanges(){
        let projectTask: ProjectTask = {
            projectTaskId: this.data.projectTask === undefined ? -1 : this.data.projectTask.projectTaskId,
            projectTaskName: this.form.get("projectTaskName")?.value,
            projectTaskItems: this.data.projectTask === undefined ? [] : this.data.projectTask.projectTaskItems,
        }
        this.projectDetailsService.createOrUpdateProjectTask(projectTask, this.data.projectId);
    }

}
