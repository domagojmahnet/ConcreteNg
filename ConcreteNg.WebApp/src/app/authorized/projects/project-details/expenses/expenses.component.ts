import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { CostOverview } from '../../../../models/cost-everview';
import { Project } from '../../../../models/project';
import { ProjectService } from '../../services/project.service';

@Component({
  selector: 'app-expenses',
  templateUrl: './expenses.component.html',
  styleUrls: ['./expenses.component.less']
})
export class ExpensesComponent implements OnInit {

    costOverviews: CostOverview[];
    totalCost: number;
    @Input() project: Project;
    @Output() projectChange = new EventEmitter<Project>();
    
    constructor(private projectService: ProjectService) { }

    ngOnInit(): void {
        this.projectService.getCostOverview(this.project.projectId).subscribe((res) =>{
            this.costOverviews = res;
            this.totalCost = this.costOverviews.reduce((n, {totalCost}) => n + totalCost, 0);
        })
    }

}
