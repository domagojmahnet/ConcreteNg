import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.less']
})
export class LoginComponent  implements OnInit {

    constructor(private authService: AuthService) {
    }


    ngOnInit(): void {
    }

    loginClick(username: string, password: string) {
        this.authService.LogUser(username, password)
    }
}
