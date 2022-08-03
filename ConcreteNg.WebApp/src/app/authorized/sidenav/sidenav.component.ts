import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { RouteLink } from '../../models/route-link';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.less']
})
export class SidenavComponent implements OnInit {

    @Input() isExpanded: boolean;
    @Output() toggleMenu = new EventEmitter();

    public routeLinks = [
        { link: "employer-overview", name: "Overview", icon: "receipt_long" },
        { link: "projects", name: "Projects", icon: "folder" },
        { link: "partners", name: "Partners", icon: "contacts" },
        { link: "pricing-list", name: "Pricing List", icon: "receipt_long" },
        { link: "locations", name: "Employees", icon: "group" },
    ];

    constructor() { }

    ngOnInit(): void {
    }

}
