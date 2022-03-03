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
        { link: "active-projects", name: "Overview", icon: "receipt_long" },
        { link: "active-projects", name: "Projects", icon: "folder" },
        { link: "active-projects", name: "Partners", icon: "contacts" },
        { link: "active-projects", name: "Payroll", icon: "receipt_long" },
        { link: "locations", name: "Employees", icon: "group" },
    ];

    constructor() { }

    ngOnInit(): void {

    }

    public toggleMenu() {
        this.isExpanded = !this.isExpanded;
    }
}
