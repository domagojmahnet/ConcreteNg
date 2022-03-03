import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { RouteLink } from '../../models/route-link';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.less']
})
export class SidenavComponent implements OnInit {

    @Input() isExpanded: boolean;
    //@Input() routeLinks: RouteLink[];
    @Output() toggleMenu = new EventEmitter();

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

}
