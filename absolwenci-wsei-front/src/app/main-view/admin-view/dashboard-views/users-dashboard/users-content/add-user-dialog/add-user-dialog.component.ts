import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import {
  UnregisteredUser,
  UnregisteredUserModel
} from '../../../../../../models/user.model';
import { UserService } from '../../../../survey-container/services/user.services';

@Component({
  selector: 'app-add-user-dialog',
  templateUrl: './add-user-dialog.component.html',
  styleUrls: ['./add-user-dialog.component.scss']
})
export class AddUserDialogComponent implements OnInit {
  loader = false;
  selected = 0;
  lastUser: number;
  groupId = 2;
  groups: object;
  constructor(private fb: FormBuilder, private userService: UserService, public dialogRef: MatDialogRef<AddUserDialogComponent>) {}

  ngOnInit() {
  }
  onSubmit(form) {
    if (form.valid) {
      const value: UnregisteredUser = form.value;
      console.log(form.value);
      this.loader = true;
      const unregUser: UnregisteredUserModel = new UnregisteredUserModel(value);
      console.log(unregUser);
      this.userService.saveUnregisteredUser(unregUser).subscribe(
        data => {
          console.log(data);
          this.userService.getAllUsers().subscribe(
            usrdata => {
              this.lastUser = usrdata[(usrdata.length) - 1].id;
              console.log(this.lastUser);
            this.userService.assignUserToGroup( usrdata[(usrdata.length) - 1].id, form.value.selectedGroup
            ).subscribe(
              userData => console.log('dodano: ' + usrdata[(usrdata.length) - 1].id + 'doGrupy ' + form.value.selectedGroup)
            );
            }
          );
          this.loader = false;
          this.dialogRef.close();
        },
        error => {
          console.log(error);
          this.loader = false;
        }
      );
    }
  }
}
