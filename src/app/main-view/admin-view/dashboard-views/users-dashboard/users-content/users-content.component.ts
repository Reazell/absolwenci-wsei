import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material';
import { BehaviorSubject, Observable, Subscription } from 'rxjs';
import {
  RegisteredUser,
  UnregisteredUser
} from '../../../../../models/user.model';
import { UserService } from '../../../survey-container/services/user.services';
import { DeleteTemplateDialogData } from './../../../../../data/shared.data';
import { ConfirmDialogComponent } from './../../../../../shared/confirm-dialog/confirm-dialog.component';
import { AddUserDialogComponent } from './add-user-dialog/add-user-dialog.component';
import { AddUserTabComponent } from './add-user-dialog/add-user-tab/add-user-tab.component';

@Component({
  selector: 'app-users-content',
  templateUrl: './users-content.component.html',
  styleUrls: ['./users-content.component.scss']
})
export class UsersContentComponent implements OnInit {
  groupTitle = 'Grupa użytkowników 1';
  buttonDets = 'Dodaj nowego użytkownika';
  emptyListInfo = 'Brak niezarejestrowanych użytkowników';
  // tslint:disable-next-line:max-line-length
  private _items$: BehaviorSubject<
    Array<RegisteredUser | UnregisteredUser>
  > = new BehaviorSubject<Array<RegisteredUser | UnregisteredUser>>(undefined);
  get items$(): Observable<Array<RegisteredUser | UnregisteredUser>> {
    return this._items$.asObservable();
  }

  // subs
  getAllUsersSub: Subscription = new Subscription();
  constructor(private userService: UserService, public dialog: MatDialog) {}

  ngOnInit() {
    this.getAllUsers();
  }
  see() {
    console.log('click');
  }
  getAllUsers() {
    this.saveUsersFromApi();
    this.getAllUsersSub = this.userService.savedUnregisteredUsers.subscribe(
      (data: Array<RegisteredUser | UnregisteredUser>) => {
        // console.log(data);
        if (data) {
          this._items$.next(data);
        }
      },
      error => {
        console.log(error);
      }
    );
  }
  openAddUserDialog(): void {
    const dialogRef: MatDialogRef<AddUserDialogComponent> = this.dialog.open(
      AddUserDialogComponent
    );
    // return dialogRef.afterClosed();
  }
  openConfimDeleteDialog(id: number): void {
    this.openSurveyDialog().subscribe((res: boolean) => {
      if (res === true) {
        this.deleteUnregisteredUser(id);
      }
    });
  }
  openUserUpdateDialog(survey): void {
    // console.log(survey);
    this.openUpdateDialog(survey).subscribe((res: any) => {
      console.log(res);
      if (res) {
        this.updateUnregisteredUser(survey.id, res);
      }
    });
  }
  updateUnregisteredUser(id, user) {
    this.userService.updateUserById(id, user).subscribe(
      data => {
        console.log(data);
      },
      error => {
        console.log(error);
      }
    );
  }
  deleteUnregisteredUser(id: number): void {
    // console.log(id);
    this.userService.deleteUserById(id).subscribe(
      () => {
        this.saveUsersFromApi();
      },
      error => {
        console.log(error);
      }
    );
  }
  saveUsersFromApi() {
    this.userService.saveUsersFromApi();
  }
  openSurveyDialog(): Observable<boolean> {
    const dialogRef: MatDialogRef<ConfirmDialogComponent> = this.dialog.open(
      ConfirmDialogComponent,
      { data: new DeleteTemplateDialogData() }
    );
    return dialogRef.afterClosed();
  }
  openUpdateDialog(survey): Observable<boolean> {
    const dialogRef: MatDialogRef<AddUserTabComponent> = this.dialog.open(
      AddUserTabComponent,
      {
        data: survey
      }
    );
    return dialogRef.afterClosed();
  }
}
