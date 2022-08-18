import { Component, Inject, OnInit, Optional } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ProjectStatusEnum } from '../../../../../../enums/project-status';
import { PricingListItem } from '../../../../../../models/pricing-list-item';
import { ProjectTaskItem } from '../../../../../../models/project-task';
import { EmployerService } from '../../../../../employer-service.service';
import { ProjectDetailsService } from '../../../project-details.service';

@Component({
  selector: 'app-add-edit-project-task-item',
  templateUrl: './add-edit-project-task-item.component.html',
  styleUrls: ['./add-edit-project-task-item.component.less']
})
export class AddEditProjectTaskItemComponent implements OnInit {

    pricingList: PricingListItem[];
    searchedPricingList: PricingListItem[];
    isCreateAction: boolean;
    status = ProjectStatusEnum['To Do'];

    public get statusEnum(): typeof ProjectStatusEnum {
        return ProjectStatusEnum; 
    }

    form = this.formBuilder.group({
        pricingListItem: ['', Validators.required],
        startDate: [],
        finishDate: [],
    });

    constructor(
        @Optional() @Inject(MAT_DIALOG_DATA) public data: {projectTaskItem: ProjectTaskItem, projectTaskId: number},
        private employerService: EmployerService,
        private projectDetailsService: ProjectDetailsService,
        private formBuilder: FormBuilder
    ) { }

    ngOnInit(): void {
        this.isCreateAction = (this.data.projectTaskItem === undefined);
        this.employerService.getPricingListItems().subscribe((res) => {
            this.pricingList = res;
            this.searchedPricingList = res;
        });
        if(!this.isCreateAction){
            this.form = this.formBuilder.group({
                pricingListItem: [this.data.projectTaskItem.pricingListItem],
                startDate: [this.data.projectTaskItem.startTime],
                finishDate: [this.data.projectTaskItem.finishTime]
            });
            this.status = this.data.projectTaskItem.taskItemStatus;
        }
    }

    onKey(value: string) { 
        this.searchedPricingList = this.search(value);
    }

    search(value: string) { 
        let filter = value.toLowerCase();
        return this.pricingList.filter(x => x.pricingListItemName.toLowerCase().includes(filter.toLowerCase()));
    }

    saveChanges(){
        if(this.form.valid){
            let projectTaskItem: ProjectTaskItem = {
                projectTaskItemId: this.data.projectTaskItem === undefined ? -1 : this.data.projectTaskItem.projectTaskItemId,
                pricingListItem: this.form.get("pricingListItem")?.value,
                startTime: this.form.get("startDate")?.value,
                finishTime: this.form.get("finishDate")?.value,
                taskItemStatus: this.data.projectTaskItem === undefined ? ProjectStatusEnum['To Do'] : this.data.projectTaskItem.taskItemStatus,
            }
            this.projectDetailsService.createOrUpdateProjectTaskItem(projectTaskItem, this.data.projectTaskId);
        }
    }

    loadValues(){

    }

    comparePricingListObjects(object1: any, object2: any) {
        return object1 && object2 && object1.pricingListItemId == object2.pricingListItemId;
    }
}
