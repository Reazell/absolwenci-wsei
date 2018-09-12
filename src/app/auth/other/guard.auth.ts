import { UserService } from '../services/user.service';
import { Injectable } from '@angular/core';
import { Router, CanLoad } from '@angular/router';

@Injectable()
export class AuthGuard implements CanLoad {
  constructor(private router: Router, private userService: UserService) {}

  canLoad() {
    if (localStorage.getItem('currentUser')) {
      // logged in so return true
      this.userService.isLogged.next(true);
      return true;
    }

    // not logged in so redirect to login page with previous url
    this.userService.isLogged.next(false);
    this.router.navigateByUrl('/auth/login');
    return false;
  }
}
