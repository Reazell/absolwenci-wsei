import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { of } from '../../../../../../node_modules/rxjs';

@Injectable()
export class DashboardResolver implements Resolve<any> {
  constructor(private router: Router) {}

  resolve(route: ActivatedRouteSnapshot): Observable<string> {
    const currentRole: string = route.params['data'];
    if (currentRole) {
      console.log(currentRole);
      // const string = '/app/admin/';
      // this.router.navigateByUrl(string);
      return of(currentRole);
    }
  }
}
