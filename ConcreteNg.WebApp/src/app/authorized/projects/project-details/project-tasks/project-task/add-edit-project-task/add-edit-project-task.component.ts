import { Component, EventEmitter, Inject, OnInit, Optional, Output } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ProjectTask } from '../../../../../../models/project-task';
import { ProjectDetailsService } from '../../../project-details.service';

@Component({
  selector: 'app-add-edit-project-task',
  templateUrl: './add-edit-project-task.component.html',
  styleUrls: ['./add-edit-project-task.component.less']
})
export class AddEditProjectTaskComponent implements OnInit {

    form = this.formBuilder.group({
        projectTaskName: ['', Validators.required]
    });

    constructor(
        @Optional() @Inject(MAT_DIALOG_DATA) public data: {projectTask: ProjectTask, projectId: number},
        private formBuilder: FormBuilder,
        private projectDetailsService: ProjectDetailsService,
        private dialogRef: MatDialogRef<AddEditProjectTaskComponent>
    ) { }

    ngOnInit(): void {
        if(this.data){
            this.form = this.formBuilder.group({
                projectTaskName: [this.data.projectTask.projectTaskName]
            });
        }
    }

    saveChanges(){
        if(this.form.valid){
            let projectTask: ProjectTask = {
                projectTaskId: this.data.projectTask === undefined ? -1 : this.data.projectTask.projectTaskId,
                projectTaskName: this.form.get("projectTaskName")?.value,
                projectTaskItems: this.data.projectTask === undefined ? [] : this.data.projectTask.projectTaskItems,
            }
            this.projectDetailsService.createOrUpdateProjectTask(projectTask, this.data.projectId).subscribe((res) => {
                this.projectDetailsService.handleProjectTaskCreateOrUpdate(projectTask, res);
                this.dialogRef.close(true);
            });
        }
    }

}
