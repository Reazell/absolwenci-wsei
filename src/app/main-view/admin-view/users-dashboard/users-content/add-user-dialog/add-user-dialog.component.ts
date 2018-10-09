import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UnregisteredUser } from '../../../../../models/user.model';
import { UserService } from '../../../survey-container/services/user.services';

@Component({
  selector: 'app-add-user-dialog',
  templateUrl: './add-user-dialog.component.html',
  styleUrls: ['./add-user-dialog.component.scss']
})
export class AddUserDialogComponent implements OnInit {
  dialogForm: FormGroup;
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
      typeofStudy: [
        '',
        Validators.compose([
          Validators.required
          // this.matchPassword
        ])
      ],
      dateOfCompletion: [
        '',
        Validators.compose([
          Validators.required
          // this.matchPassword
        ])
      ]
    });
  }
  onSubmit(value) {
    console.log(value);
    const unregUser: UnregisteredUser = {
      Name: value.name,
      Surname: value.surname,
      Email: value.email,
      Course: value.course,
      TypeOfStudy: value.typeOfStudy,
      CompletionDate: value.dateOfCompletion
    };
    this.userService.saveUnregisteredUser(unregUser).subscribe(
      data => {
        console.log(data);
      },
      error => {
        console.log(error);
      }
    );
  }
}
