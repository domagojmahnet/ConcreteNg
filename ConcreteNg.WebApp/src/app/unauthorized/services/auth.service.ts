import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

    constructor(
        private http: HttpClient, 
        private toastr: ToastrService,
        private router: Router,
        ) {
    }

  userUrl: string = environment.BASE_URL+ "api/Auth";

  LogUser(username: string, password: string) {
        const data = {"Username" : username, "Password" : password};

        this.http.post<any>(this.userUrl + "/login", data).subscribe((token: any)=>{
            localStorage.setItem('token', token);

            //this.router.navigate(['/','home']);
            //TODO get this in interceptor
            var header = {
                headers: new HttpHeaders()
                    .set('Authorization',  `bearer ${token}`)
                }
            this.http.get(environment.BASE_URL + "api/WeatherForecast", header).subscribe((weather: any)=>{
                console.log(weather);
                debugger;
            })
        })
    }
}
