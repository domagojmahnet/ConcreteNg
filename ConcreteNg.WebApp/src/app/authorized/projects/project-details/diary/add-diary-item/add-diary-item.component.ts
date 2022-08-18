import { Component, Inject, OnInit, Optional } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DiaryItem } from '../../../../../models/diary-item';
import { Project } from '../../../../../models/project';
import { ProjectService } from '../../../services/project.service';

@Component({
  selector: 'app-add-diary-item',
  templateUrl: './add-diary-item.component.html',
  styleUrls: ['./add-diary-item.component.less']
})
export class AddDiaryItemComponent implements OnInit {

    form = this.formBuilder.group({
        description: ['', Validators.required]
    });

    constructor(
        @Optional() @Inject(MAT_DIALOG_DATA) public data: {project: Project},
        private dialogRef: MatDialogRef<AddDiaryItemComponent>,
        private formBuilder: FormBuilder,
        private projectService: ProjectService
    ) { }

    ngOnInit(): void {

    }

    saveChanges(){
        if(this.form.valid){
            let diaryItem: DiaryItem = {
                diaryItemId: -1,
                dateTime: new Date(),
                description: this.form.get("description")?.value
            }

            this.projectService.addDIaryItem(diaryItem, this.data.project.projectId).subscribe(() => {
                this.dialogRef.close(true);
            });
        }
    }

}
