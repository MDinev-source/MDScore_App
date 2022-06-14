import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate {

  constructor(private authService: AuthService, private router: Router) { }

  canActivate(): boolean {

    let isOrganizer = this.authService.isOrganizer();
    let isAuth = this.authService.isAuthenticated();

    if (isAuth && isOrganizer) {
      return true
    } else {

      if (isAuth && !isOrganizer) {
        this.router.navigate(["/"]);
      }
      else {
        this.router.navigate(["login"]);
      }

      return false;
    }
  }
}
