import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { environment } from '../../../environments/environment';
import { AccountService } from '../../account.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

    constructor(
        private http: HttpClient, 
        private toastr: ToastrService,
        private router: Router,
        private accountService: AccountService
        ) {
    }


    userUrl: string = environment.BASE_URL+ "api/Auth";

    LogUser(username: string, password: string) {
        const data = {"Username" : username, "Password" : password};

        this.http.post<any>(this.userUrl + "/login", data).subscribe((token: any)=>{
            debugger
            this.accountService.JwtTokenValue = token

            this.http.get(environment.BASE_URL + "api/User").subscribe((weather: any)=>{
                console.log(weather);
            })
        })
    }
}
