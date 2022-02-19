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

  userUrl: string = environment.BASE_URL+ "api/user";

  LogUser(username: string, password: string) {
    const data = {'username': username, 'password': password};
    const httpOptions: { headers: any; observe: any; } = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',
        'username': username,
        'password': password
      }),
      observe: 'body'
    };

    return this.http.post<any>(this.userUrl + "/login", data, httpOptions).subscribe((result: any) => {
      //localStorage.setItem('currentUser:firstName', JSON.stringify(result));
          this.router.navigate(['']);
      }, (error) => {
        if(error.status == 400){
          this.toastr.error("Invalid user credentials")
        }
     })
  }
}
