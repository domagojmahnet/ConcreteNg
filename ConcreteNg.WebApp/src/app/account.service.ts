import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { User } from './models/user';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

    LoggedIn = new Subject();

    public get userValue(): any {
        return JSON.parse(sessionStorage.getItem('currentUser') || '{}') as User;
    }

    public set userValue(user: User) {
        sessionStorage.setItem('currentUser', JSON.stringify(user));
    }

    public get JwtTokenValue(): any{
        return sessionStorage.getItem('token') as string;
    }

    public set JwtTokenValue(token: string) {
        this.LoggedIn.next(true)
        sessionStorage.setItem('token', token);
    }

    public clearCurrentUser(): void {
        this.LoggedIn.next(false)
        sessionStorage.clear();
    }
}
