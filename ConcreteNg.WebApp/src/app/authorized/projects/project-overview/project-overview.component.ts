import { Component, OnInit } from '@angular/core';
import { ProjectService } from '../services/project.service';

@Component({
  selector: 'app-project-overview',
  templateUrl: './project-overview.component.html',
  styleUrls: ['./project-overview.component.less']
})
export class ProjectOverviewComponent implements OnInit {

    public isExpanded = false;
    public routeLinks = [
        { link: "active-projects", name: "Active projects", icon: "receipt_long" },
        { link: "locations", name: "Locations", icon: "account_balance" },
    ];

    constructor() { }

    ngOnInit(): void {

    }

    public toggleMenu() {
        this.isExpanded = !this.isExpanded;
    }
}
