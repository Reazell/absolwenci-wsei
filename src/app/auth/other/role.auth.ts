import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router } from '@angular/router';
import { SharedService } from '../../services/shared.service';
import { UserService } from '../services/user.service';

@Injectable()
export class RoleGuard implements CanActivate {
  constructor(
    private userService: UserService,
    private sharedService: SharedService,
    private router: Router
  ) {}

  canActivate(route: ActivatedRouteSnapshot): boolean {
    const expectedRole: string = route.data.expectedRole;
    const currentRole: string = JSON.parse(localStorage.getItem('currentUser'))
      .role;
    if (currentRole === expectedRole) {
      this.userService.setRoleSubject(expectedRole);
      return true;
    } else {
      if (this.userService.isLogged.value === true) {
        console.log(currentRole);
        this.sharedService.routeSwitch(currentRole);
      } else {
        this.router.navigateByUrl('auth/login');
      }
      return false;
    }
  }
}
