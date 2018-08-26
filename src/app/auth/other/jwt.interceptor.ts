import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse,
  HttpResponse,
  HttpHeaders
} from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/do';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
  constructor(private router: Router) {}
  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    // add authorization header with jwt token if available
    const currentUser = JSON.parse(localStorage.getItem('currentUser'));
    if (currentUser && currentUser.token) {
      const cloned = req.clone({
        headers: new HttpHeaders({
          Authorization: 'Bearer ' + currentUser.token
        })
      });

      return next.handle(cloned).do(
        (event: HttpEvent<any>) => {
          if (event instanceof HttpResponse) {
            // do stuff with response if you want
          }
        },
        (err: any) => {
          if (err instanceof HttpErrorResponse) {
            console.log(err);
            if (err.status === 401 || err.status === 403) {
              // redirect to the login route
              // or show a modal
              this.router.navigateByUrl(`/auth/login`);
            }
          }
        }
      );
    } else {
      return next.handle(req);
    }
  }
}
