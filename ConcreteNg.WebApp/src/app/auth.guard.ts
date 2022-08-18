import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AccountService } from './account.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

    constructor(
        private accService: AccountService,
        private router: Router) 
    { }

    canActivate(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): boolean {
            const isAuthenticated = (this.accService.JwtTokenValue !== null);
            const userRole = this.accService.userValue?.userType;
            if (!isAuthenticated) {
                this.router.navigate(['/home']);
            }
            return isAuthenticated;
    }
} 