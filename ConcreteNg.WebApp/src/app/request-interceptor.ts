import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpErrorResponse } from '@angular/common/http';
import { catchError, Observable, tap, throwError } from 'rxjs';
import { AccountService } from './account.service';


@Injectable()
export class RequestInterceptor implements HttpInterceptor {
    
    constructor(private accountService: AccountService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const token = this.accountService.JwtTokenValue
        if (token) {
            request = request.clone({
                setHeaders: { Authorization: `bearer ${token}` }
            });
        }
        return next.handle(request).pipe(
            catchError((requestError) => {
              if (requestError.status === 401) {
                const { error } = requestError;
              }
              return throwError(() => new Error(requestError));
            })
        )
    }
}