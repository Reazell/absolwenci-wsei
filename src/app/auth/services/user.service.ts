import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { AppConfig } from '../../app.config';

@Injectable()
export class UserService {
  mail: string;
  isLogged: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(undefined);
  role: BehaviorSubject<string> = new BehaviorSubject<string>(undefined);
  constructor(private http: HttpClient, private config: AppConfig) {}

  isLoggedNext(x) {
    this.isLogged.next(x);
  }
  setRoleSubject(x) {
    this.role.next(x);
  }
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
    return this.http.post(
      this.config.apiUrl + '/auth/changePasswordByRestoringPassword',
      {
        Token,
        NewPassword
      }
    );
  }

  // update user data

  updateProfile(user) {
    return this.http.put(this.config.apiUrl + `/accountupdate/${user.id}`, {
      Name: user.name,
      Surname: user.surname,
      Email: user.email,
      PhoneNumber: user.phoneNum,
      CompanyName: user.companyName,
      Location: user.location,
      CompanyDescription: user.companyDescription
    });
  }

  // recovery password
  passMailData(mail) {
    this.mail = mail;
  }
  getMailData() {
    const mail = this.mail;
    this.mail = undefined;
    return mail;
  }
}
