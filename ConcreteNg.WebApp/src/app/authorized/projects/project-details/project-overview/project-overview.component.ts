import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { DialogPosition, MatDialog } from '@angular/material/dialog';
import { LegendPosition } from '@swimlane/ngx-charts';
import { AccountService } from '../../../../account.service';
import { ProjectStatusEnum } from '../../../../enums/project-status';
import { UserTypeEnum } from '../../../../enums/user-type';
import { GraphData, PieGrid, TaskCompletion } from '../../../../models/graph-models/graph-data';
import { Project } from '../../../../models/project';
import { User } from '../../../../models/user';
import { AddEditUserComponent } from '../../../users/add-edit-user/add-edit-user.component';
import { ProjectService } from '../../services/project.service';
import { ProjectDetailsService } from '../project-details.service';

@Component({
  selector: 'app-project-overview',
  templateUrl: './project-overview.component.html',
  styleUrls: ['./project-overview.component.less']
})
export class ProjectOverviewComponent implements OnInit {

    @Input() project: Project;
    @Output() projectChange = new EventEmitter<Project>();

    graphData: GraphData;
    projectStatusEnum = ProjectStatusEnum;
    userRole: UserTypeEnum | undefined;

    public get userTypeEnum(): typeof UserTypeEnum {
        return UserTypeEnum; 
    }

    legend: boolean = true;
    legendPosition: LegendPosition = LegendPosition.Right;

    constructor(
        public dialog: MatDialog,
        private projectDetailsService: ProjectDetailsService,
        private projectService: ProjectService,
        private accountService: AccountService
    ) { }

    ngOnInit(): void {
        this.userRole = this.accountService.userValue?.userType;
        this.projectService.getProjectGraphData(this.project.projectId).subscribe((res) =>{
            this.graphData = res;
        })
    }

    OpenAddEditItemDialog(){
        this.projectDetailsService.getProjectBuyer(this.project.projectId).subscribe((res) => {
            let user = res ?? undefined
            const dialogPosition: DialogPosition = {
                right: 0 + 'px',
            }
              
            const dialogRef = this.dialog.open(AddEditUserComponent, {
                width: '450px',
                height: '100%',
                position: dialogPosition,
                data: {user: user, isBuyerAccount: true}
            });
    
            dialogRef.afterClosed().subscribe((res) => {
                if(user === undefined && res !== undefined){ 
                    this.projectDetailsService.assignBuyerToProject(res.userId, this.project.projectId).subscribe();
                }
            });
        })
    }

    updateProjectStatus(projectStatus: ProjectStatusEnum){
        this.projectService.updateProjectStatus(projectStatus, this.project.projectId).subscribe((data) => {
            this.project.projectStatus = projectStatus;
            this.projectChange.emit(this.project);
        })
    }
}
