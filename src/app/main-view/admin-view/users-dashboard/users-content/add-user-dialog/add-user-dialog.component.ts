import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import * as _moment from 'moment';
import {
  UnregisteredUser,
  UnregisteredUserModel
} from '../../../../../models/user.model';
import { UserService } from '../../../survey-container/services/user.services';

@Component({
  selector: 'app-add-user-dialog',
  templateUrl: './add-user-dialog.component.html',
  styleUrls: ['./add-user-dialog.component.scss']
})
export class AddUserDialogComponent implements OnInit {
  dialogForm: FormGroup;
  loader = false;
  constructor(private fb: FormBuilder, private userService: UserService) {}

  ngOnInit() {
    this.dialogForm = this.fb.group({
      name: [
        '',
        Validators.compose([
          Validators.required
          // Validators.pattern(this.namePattern)
        ])
      ],
      surname: [
        '',
        Validators.compose([
          Validators.required
          // Validators.pattern(this.surnamePattern)
        ])
      ],
      email: [
        '',
        Validators.compose([
          Validators.required
          // Validators.pattern(this.emailPattern)
        ])
      ],
      course: [
        '',
        Validators.compose([
          Validators.required
          // Validators.pattern(this.passwordPattern)
        ])
      ],
      typeOfStudy: [
        '',
        Validators.compose([
          Validators.required
          // this.matchPassword
        ])
      ],
      completionDate: [
        '',
        Validators.compose([
          Validators.required
          // this.matchPassword
        ])
      ]
    });
  }
  onSubmit(form) {
    const value: UnregisteredUser = form.value;
    console.log(value);
    this.loader = true;
    if (form.valid) {
      const unregUser: UnregisteredUserModel = new UnregisteredUserModel(value);
      console.log(JSON.stringify(unregUser));
      this.userService.saveUnregisteredUser(unregUser).subscribe(
        data => {
          // console.log(data);
          this.loader = false;
        },
        error => {
          console.log(error);
        }
      );
    }
  }
}
