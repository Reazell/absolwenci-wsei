import { Component, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  NgForm,
  Validators
} from '@angular/forms';
import { Router } from '@angular/router';
import { SharedService } from '../../services/shared.service';
import { AuthenticationService } from '../services/authentication.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-password-change',
  templateUrl: './password-change.component.html',
  styleUrls: ['./password-change.component.scss']
})
export class PasswordChangeComponent implements OnInit {
  // declare form
  passwordForm: FormGroup;
  oldPassword: AbstractControl;
  newPassword: AbstractControl;
  confirmPassword: AbstractControl;

  // loader
  loading = false;

  // error handlers
  oldPasswordErrorStr: string;
  newPasswordErrorStr: string;
  confirmPasswordErrorStr: string;

  loginError = false;
  loginErrorMessage = '';

  // tslint:disable-next-line:max-line-length
  passwordPattern = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}/;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private authenticationService: AuthenticationService,
    private userService: UserService,
    private sharedService: SharedService
  ) {}

  ngOnInit() {
    // form declaration
    this.passwordForm = this.fb.group({
      oldPassword: ['', Validators.compose([Validators.required])],
      newPassword: [
        '',
        Validators.compose([
          Validators.required,
          Validators.pattern(this.passwordPattern)
        ])
      ],
      confirmPassword: [
        '',
        Validators.compose([Validators.required, this.matchPassword])
      ]
    });

    // connecting controls with form inputs
    this.oldPassword = this.passwordForm.controls['oldPassword'];
    this.newPassword = this.passwordForm.controls['newPassword'];
    this.confirmPassword = this.passwordForm.controls['confirmPassword'];
  }

  onSubmit(form: NgForm): void {
    if (!form.valid) {
      // showing possible errors
      this.oldPassword.markAsTouched();
      this.newPassword.markAsTouched();
    } else {
      this.loading = true;
      this.userService
        // login with credentials from form
        .changePassword(this.oldPassword.value, this.newPassword.value)
        .subscribe(
          data => {
            // console.log(data);
            this.userService.isLoggedNext(false);
            this.router.navigateByUrl('auth/login');
          },
          error => {
            // console.log(error);
            // set error message from api to loginErrorMessage
            this.loginError = true;
            this.loginErrorMessage = 'Nieprawidłowy mail lub hasło';
            this.loading = false;
          }
        );
    }
  }

  inputError(control: AbstractControl): boolean {
    // get error message and control name in string
    const errorObj = this.sharedService.inputError(control);

    // assign error to input
    if (errorObj) {
      switch (errorObj.controlName) {
        case 'old password':
          this.oldPasswordErrorStr = errorObj.errorStr;
          break;
        case 'new password':
          this.newPasswordErrorStr = errorObj.errorStr;
          break;
      }
      return true;
    }
  }

  onFocus(control: AbstractControl): void {
    // hide possible errors
    // if (control.touched) {
    control.markAsUntouched();
    // }
    this.loginError = false;
  }

  onBlur(control: AbstractControl): void {
    // hide possible errors
    if (control.dirty === false) {
      control.markAsUntouched();
      this.loginError = false;
    }
  }

  matchPassword(control: AbstractControl): { [s: string]: boolean } {
    // check if inputs have same values
    if (control.parent !== undefined) {
      const password = control.parent.get('newPassword').value;
      const passwordConfirm = control.parent.get('confirmPassword').value;
      if (password !== passwordConfirm) {
        return { noMatch: true };
      }
    }
  }

  passwordNoMatch(): boolean {
    /*show error while passwords do not match*/
    if (this.confirmPassword.errors) {
      if (this.confirmPassword.errors.noMatch === undefined) {
        this.confirmPasswordErrorStr = 'Passwords do not match';
        return true;
      }
    } else {
      return false;
    }
  }
}
