import { Component, Inject, OnInit, Optional } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { ProjectStatusEnum } from '../../../enums/project-status';
import { Project } from '../../../models/project';
import { User } from '../../../models/user';
import { ProjectService } from '../services/project.service';

@Component({
  selector: 'app-add-edit-project',
  templateUrl: './add-edit-project.component.html',
  styleUrls: ['./add-edit-project.component.less']
})
export class AddEditProjectComponent implements OnInit {
    
    eligibleManagers: User[];
    searchedEligibleManagers: User[];

    form = this.formBuilder.group({
        name: ['', Validators.required],
        expectedStartDate: ['', Validators.required],
        expectedEndDate: ['', Validators.required],
        expectedCost: ['', Validators.required],
        manager: ['', Validators.required]
    });

    constructor(
        @Optional() @Inject(MAT_DIALOG_DATA) public data: {project: Project},
        private dialogRef: MatDialogRef<AddEditProjectComponent>,
        private formBuilder: FormBuilder,
        private projectService: ProjectService,
        private toastr: ToastrService
    ) { }

    ngOnInit(): void {
        this.projectService.getEligibleManagers().subscribe((res) => {
            this.eligibleManagers = res;
            this.searchedEligibleManagers = res;
        });

        this.projectService.getManager(this.data.project.projectId).subscribe((res) => {
            this.form
        })

        if(this.data){
            this.projectService.getManager(this.data.project.projectId).subscribe((res) => {
                let a = this.searchedEligibleManagers.find(x => x.userId === res.userId);
                this.form = this.formBuilder.group({
                    name: this.data.project.name,
                    expectedStartDate: this.data.project.expectedStartDate,
                    expectedEndDate: this.data.project.expectedEndDate,
                    expectedCost: this.data.project.expectedCost,
                    manager: this.searchedEligibleManagers.find(x => x.userId === res.userId)
                });
            });
        }
    }

    saveChanges(){
        if(this.form.valid){
            let project: Project = {
                projectId: this.data.project === undefined ? -1 : this.data.project.projectId,
                name: this.form.get("name")?.value,
                expectedStartDate: this.form.get("expectedStartDate")?.value,
                expectedEndDate: this.form.get("expectedEndDate")?.value,
                expectedCost: this.form.get("expectedCost")?.value,
                projectStatus: this.data.project === undefined ? ProjectStatusEnum['To Do'] : this.data.project.projectStatus,
                currentCost: 0
            }
            this.projectService.AddEditProject(project, this.form.get("manager")?.value.userId).subscribe(() => {
                this.toastr.success("Succesfully added/edited project!", "",{
                    positionClass: 'toast-top-full-width'
                });
                this.dialogRef.close(true);
            });
        }
    }
    
    onKey(value: string) { 
        this.searchedEligibleManagers = this.search(value);
    }

    search(value: string) { 
        let filter = value.toLowerCase();
        return this.eligibleManagers.filter(x => (x.firstName.toLowerCase() + " " + x.lastName.toLowerCase()).includes(filter));
    }

    compareUserObjects(object1: User, object2: User) {
        return object1 && object2 && object1.userId === object2.userId;
    }
}
