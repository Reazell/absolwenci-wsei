import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { AppConfig } from '../../../../app.config';
import {
  RegisteredUser,
  UnregisteredUser
} from '../../../../models/user.model';

@Injectable()
export class UserService {
  constructor(private http: HttpClient, private config: AppConfig) {}

  getAllUsers(): Observable<Array<UnregisteredUser | RegisteredUser>> {
    return this.http
      .get<any[]>(this.config.apiUrl + '/importfile/unregisteredUsers')
      .map(data => {
        return data;
      });
  }
  saveUnregisteredUser(user) {
    return this.http
      .post<any>(this.config.apiUrl + '/importfile/unregisteredUsers', {
        user
      })
      .map(data => {
        return data;
      });
  }
}
