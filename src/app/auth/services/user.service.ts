import { Observable } from 'rxjs/Observable';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AppConfig } from '../../app.config';
import { RequestOptions } from '@angular/http';

@Injectable()
export class UserService {
  constructor(private http: HttpClient, private config: AppConfig) {}

  subject$ = new BehaviorSubject<any>(null);
  user$: Observable<any> = this.subject$.asObservable();
  isLogged: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);

  // create new user
  // create(user: User) {
  //   const Email = user.email;
  //   const Password = user.password;
  //   const Name = user.firstName;
  //   const Surname = user.lastName;
  //   const Country = user.country;
  //   const ProfileName = user.profileName;
  //   return this.http.post(this.config.apiUrl + '/auth/register', {
  //     Email,
  //     Password,
  //     Name,
  //     Surname,
  //     Country,
  //     ProfileName
  //   });
  // }

  // // change password
  // changePassword(OldPassword, NewPassword) {
  //   return this.http.post(
  //     this.config.apiUrl + '/auth/changePassword',
  //     { OldPassword, NewPassword },
  //     { headers: this.jwt() }
  //   );
  // }

  // // restore password
  // sendRestorePasswordEmail(Email) {
  //   return this.http.post(this.config.apiUrl + '/auth/restorePassword', {
  //     Email
  //   });
  // }

  // changePasswordByRestoringPassword(Email, Token, NewPassword) {
  //   return this.http.put(this.config.apiUrl + '/auth/restorePassword', {
  //     Email,
  //     Token,
  //     NewPassword
  //   });
  // }

  // // update user data
  // update(user: User) {
  //   return this.http.put(this.config.apiUrl + '/users/' + user.id, user);
  // }

  // // delete user by id
  // delete(id: number) {
  //   return this.http.delete('/users/' + id);
  // }

  // getUser() {
  //   return this.http.get<any>(this.config.apiUrl + '/profile');
  // }

  // // getUser() {
  // //   return this.http
  // //     .get<any>(this.config.apiUrl + '/user/account')
  // //     .map(data => {
  // //       return data;
  // //     });
  // // }

  // private jwt() {
  //   // create authorization header with jwt token
  //   const currentUser = JSON.parse(localStorage.getItem('currentUser'));
  //   if (currentUser && currentUser.token) {
  //     let headers = new HttpHeaders();
  //     headers = headers.append('Content-Type', 'application/json');
  //     headers = headers.append('Authorization', 'Bearer ' + currentUser.token);
  //     return headers;
  //   }
  // }
}
