import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AccountService } from './account.service';


@Injectable()
export class RequestInterceptor implements HttpInterceptor {
    
    constructor(private accountService: AccountService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const token = this.accountService.jwtToken;
        if (token) {
            request = request.clone({
                setHeaders: { Authorization: `bearer ${token}` }
            });
        }
        return next.handle(request);
    }
}