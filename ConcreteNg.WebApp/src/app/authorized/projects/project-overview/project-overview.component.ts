import { Component, OnInit } from '@angular/core';

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

    public toggleMenu() {
        this.isExpanded = !this.isExpanded;
    }

    constructor() { }

    ngOnInit(): void {
    }

}
