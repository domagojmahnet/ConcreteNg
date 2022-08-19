import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { DialogPosition, MatDialog } from '@angular/material/dialog';
import { Project } from '../../../../models/project';
import { User } from '../../../../models/user';
import { AddEditUserComponent } from '../../../users/add-edit-user/add-edit-user.component';
import { ProjectDetailsService } from '../project-details.service';

@Component({
  selector: 'app-project-overview',
  templateUrl: './project-overview.component.html',
  styleUrls: ['./project-overview.component.less']
})
export class ProjectOverviewComponent implements OnInit {

    @Input() project: Project;
    @Output() projectChange = new EventEmitter<Project>();
    
    constructor(
        public dialog: MatDialog,
        private projectDetailsService: ProjectDetailsService
    ) { }

    ngOnInit(): void {
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
                debugger;
                if(user === undefined && res !== undefined){ 
                    this.projectDetailsService.assignBuyerToProject(res.userId, this.project.projectId).subscribe();
                }
            });
        })
    }

    view: any[] = [500, 400];

    // options
    showLegend: boolean = true;
    showLabels: boolean = true;

    colorScheme = {
        domain: ['#5AA454', '#E44D25', '#CFC0BB', '#7aa3e5', '#a8385d', '#aae3f5']
    };

    onSelect(event: any) {
        console.log(event);
    }

    single = [
        {
          "name": "Germany",
          "value": 8940000
        },
        {
          "name": "USA",
          "value": 5000000
        },
        {
          "name": "France",
          "value": 7200000
        },
        {
          "name": "UK",
          "value": 6200000
        },
        {
          "name": "Italy",
          "value": 4200000
        },
        {
          "name": "Spain",
          "value": 8200000
        }
      ];
}
