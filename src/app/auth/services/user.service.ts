import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppConfig } from '../../app.config';
import { User } from '../../models/user.model';

@Injectable()
export class UserService {
  mail: string;
  isLogged: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);

  constructor(private http: HttpClient, private config: AppConfig) {}

  // create new user

  createStudent(user) {
    return this.http.post(this.config.apiUrl + '/auth/students', {
      IndexNumber: user.albumID,
      Email: user.email,
      Password: user.password,
      Name: user.firstName,
      Surname: user.lastName,
      PhoneNumber: user.phoneNum
    });
  }
  createGraduate(user) {
    return this.http.post(this.config.apiUrl + '/auth/graduates', {
      Email: user.email,
      Password: user.password,
      Name: user.firstName,
      Surname: user.lastName,
      PhoneNumber: user.phoneNum
    });
  }
  createEmployer(user) {
    return this.http.post(this.config.apiUrl + '/auth/employers', {
      IndexNumber: user.albumID,
      Email: user.email,
      Password: user.password,
      Name: user.firstName,
      Surname: user.lastName,
      PhoneNumber: user.phoneNum,
      CompanyName: user.companyName,
      Location: user.location,
      CompanyDescription: user.companyDescription
    });
  }
  // change password
  changePassword(OldPassword, NewPassword) {
    return this.http.post(this.config.apiUrl + '/auth/changePassword', {
      OldPassword,
      NewPassword
    });
  }

  // restore password
  sendRestorePasswordEmail(Email) {
    return this.http.post(this.config.apiUrl + '/auth/restorePassword', {
      Email
    });
  }

  changePasswordByRestoringPassword(Token, NewPassword) {
    return this.http.post(this.config.apiUrl + '/auth/changePasswordByRestoringPassword', {
      Token,
      NewPassword
    });
  }

  // update user data
  update(user: User) {
    return this.http.put(this.config.apiUrl + '/users/' + user.id, user);
  }

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
  passMailData(mail) {
    this.mail = mail;
  }
  getMailData() {
    const mail = this.mail;
    this.mail = undefined;
    return mail;
  }
}
