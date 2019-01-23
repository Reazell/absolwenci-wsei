import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material';
import { BehaviorSubject, Observable, Subscription } from 'rxjs';
import {
  RegisteredUser,
  UnregisteredUser
} from '../../../../../models/user.model';
import { UserService } from '../../../survey-container/services/user.services';
import { DeleteTemplateDialogData } from './../../../../../data/shared.data';
import { UnregisteredUserModel } from './../../../../../models/user.model';
import { ConfirmDialogComponent } from './../../../../../shared/confirm-dialog/confirm-dialog.component';
import { AddUserDialogComponent } from './add-user-dialog/add-user-dialog.component';
import { AddUserTabComponent } from './add-user-dialog/add-user-tab/add-user-tab.component';

@Component({
  selector: 'app-users-content',
  templateUrl: './users-content.component.html',
  styleUrls: ['./users-content.component.scss']
})
export class UsersContentComponent implements OnInit {
  groupTitle = 'Użytkownicy i grupy';
  buttonDets = 'Dodaj';
  emptyListInfo = 'Brak niezarejestrowanych użytkowników';
  // tslint:disable-next-line:max-line-length
  private _items$: BehaviorSubject<
    Array<RegisteredUser | UnregisteredUser>
  > = new BehaviorSubject<Array<RegisteredUser | UnregisteredUser>>(undefined);
  get items$(): Observable<Array<RegisteredUser | UnregisteredUser>> {
    return this._items$.asObservable();
  }
  groups$: object;

  // subs
  getAllUsersSub: Subscription = new Subscription();
  constructor(private userService: UserService, public dialog: MatDialog) {}

  ngOnInit() {
    this.getAllUsers();
    this.getAllGroups();
  }
  see() {
    console.log('click');
  }
  addUserToGroup(userId, groupId) {
    this.userService.assignUserToGroup(userId, groupId).subscribe(data => console.log(data));
  }
  removeUserFromGroup(userId, groupId) {
    this.userService.removeUserFromGroup(userId, groupId).subscribe(
      () => {
        this.saveUsersFromApi();
        this.getAllGroups();
      },
      error => {
        console.log(error);
      }
    );
  }
  addNewGroup(name) {
    this.userService.addGroup(name).subscribe(data => console.log(data));
  }
  getAllGroups() {
    this.userService.getGroups().subscribe(data => this.groups$ = data);
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
  deleteGroup(groupId) {
    this.userService.deleteGroup(groupId).subscribe(data =>{
      console.log('deleted');
      this.getAllGroups();
    }
    );
  }
  openAddUserDialog(groupID): void {
    const dialogRef: MatDialogRef<AddUserDialogComponent> = this.dialog.open(
      AddUserDialogComponent,
    );
    dialogRef.afterClosed().subscribe(result => {
      console.log('DialogClosed');
      this.getAllGroups();
    });
  }
  // openConfimDeleteDialog(id: number): void {
  //   this.openSurveyDialog().subscribe((res: boolean) => {
  //     if (res === true) {
  //       this.deleteUnregisteredUser(id);
  //     }
  //   });
  // }
  openConfimDeleteDialog(userId: number, groupId: number): void {
    this.openSurveyDialog().subscribe((res: boolean) => {
      if (res === true) {
        this.removeUserFromGroup(userId,groupId);
      }
    });
  }
  openUserUpdateDialog(user): void {
    // console.log(survey);
    this.openUpdateDialog(user).subscribe((res: any) => {
      console.log(res);
      if (res) {
        this.updateUnregisteredUser(user.id, res);
      }
    });
  }
  updateUnregisteredUser(id, user) {
    const usermodel: UnregisteredUserModel = new UnregisteredUserModel(user);
    this.userService.updateUserById(id, usermodel).subscribe(
      data => {
        console.log(data);
        this.getAllUsers();
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
        this.getAllGroups();
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
