import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AccountService } from '../../account.service';
import { UserTypeEnum } from '../../enums/user-type';
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
    ];

    constructor(private accountService: AccountService) { }

    ngOnInit(): void {
        if(this.accountService.userValue?.userType !== UserTypeEnum.Buyer){
            this.routeLinks = [...this.routeLinks, ...[
                { link: "partners", name: "Partners", icon: "contacts" },
                { link: "pricing-list", name: "Pricing List", icon: "receipt_long" },
                ]
            ]
        }
        if(this.accountService.userValue?.userType === UserTypeEnum.Administrator){
            this.routeLinks = [...this.routeLinks, ...[
                { link: "employees", name: "Employees", icon: "group" },
                ]
            ]
        }
    }
}
