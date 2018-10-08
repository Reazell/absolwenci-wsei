import { Injectable } from '@angular/core';
import { CanLoad, Router } from '@angular/router';
import { UserService } from '../services/user.service';

@Injectable()
export class AuthGuard implements CanLoad {
  constructor(private router: Router, private userService: UserService) {}

  canLoad() {
    if (localStorage.getItem('currentUser')) {
      // logged in so return true
      this.userService.isLoggedNext(true);
      return true;
    }

    // not logged in so redirect to login page with previous url
    this.userService.isLoggedNext(false);
    this.router.navigateByUrl('/auth/login');
    return false;
  }
}
