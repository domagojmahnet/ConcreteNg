import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import { User } from './models/user';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

    public currentUser: any;
    public jwtToken: any;

    public get userValue(): User {
        return this.currentUser;
    }

    public set userValue(user: User) {
        this.currentUser = user;
    }

    public get JwtTokenValue(): string{
        return this.jwtToken;
    }

    public set JwtTokenValue(token: string) {
        this.jwtToken = token;
    }

    public clearCurrentUser(): void {
        this.jwtToken = null;
        this.currentUser = null;
    }
}
