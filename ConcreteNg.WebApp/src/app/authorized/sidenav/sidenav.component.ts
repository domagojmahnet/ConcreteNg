import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { RouteLink } from '../../models/route-link';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.less']
})
export class SidenavComponent implements OnInit {

    @Input() isExpanded: boolean;
    @Input() routeLinks: RouteLink[];
    @Output() toggleMenu = new EventEmitter();

    constructor() { }

    ngOnInit(): void {
    }

}
