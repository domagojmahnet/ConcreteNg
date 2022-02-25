import { Component, OnInit } from '@angular/core';
import { AccountService } from '../account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.less']
})
export class NavComponent implements OnInit {

    LoggedIn: any;

    constructor(private accountService: AccountService) { }

    ngOnInit(): void {
        debugger;
        if(this.accountService.JwtTokenValue){
            this.LoggedIn = true
        }

        this.accountService.LoggedIn.subscribe((value) => {
            this.LoggedIn = value
        })
    }

    public LogOut(){
        this.accountService.clearCurrentUser();
    }

}
