import { SharedService } from './../../services/shared.service';
import { UserService } from '../services/user.service';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router } from '@angular/router';

@Injectable()
export class RoleGuard implements CanActivate {
  constructor(
    private userService: UserService,
    private sharedService: SharedService,
    private router: Router
  ) {}

  canActivate(route: ActivatedRouteSnapshot) {
    const expectedRole = route.data.expectedRole;
    const currentRole = JSON.parse(localStorage.getItem('currentUser')).role;
    if (currentRole === expectedRole) {
      return true;
    } else {
      if (this.userService.isLogged.value === true) {
        this.sharedService.routeSwitch(currentRole);
      } else {
        this.router.navigateByUrl('auth/login');
      }
      return false;
    }
  }
}
