import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivate,
  Router,
  RouterStateSnapshot
} from '@angular/router';

/**
 * Guard check if guid has valid length.
 *
 * @export
 * @class GuidGuard
 * @implements {CanActivate}
 * check if in url is appropriate guid length and depend on it return boolean.
 */
@Injectable()
export class GuidGuard implements CanActivate {
  href: string[];
  token: string;
  constructor(private router: Router) {}

  /**
   * Check if guid has valid length.
   *
   * @param {ActivatedRouteSnapshot} route
   * @param {RouterStateSnapshot} state
   * @returns {boolean} If true guid is valid
   * @memberof GuidGuard
   */
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    this.href = state.url.split('/');
    this.token = this.href[this.href.length - 1];
    this.token = this.token.replace(/-/g, '');
    if (this.token.length === 32) {
      return true;
    }
    // not logged in so redirect to login page with previous url
    this.router.navigate(['/auth/login']);
    return false;
  }
}
