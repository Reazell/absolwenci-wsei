import { Component, OnInit, HostBinding } from '@angular/core';
import {
  FormGroup,
  NgForm,
  FormBuilder,
  Validators,
  AbstractControl
} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MatDialog } from '@angular/material';
import { PasswordRecoveryComponent } from './password-recovery/password-recovery.component';
import { AuthenticationService } from './../services/authentication.service';
import { basicTransition } from '../other/router.animations';

/**
 * Sign in user.
 *
 * @export
 * @class LoginComponent
 * @implements {OnInit} Reset login status (log out), get last url, init login form.
 *
 */

@Component({
  moduleId: module.id,
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  // animations: [trigtrans]
})
export class LoginComponent implements OnInit {
  // @HostBinding('@trigtrans')
  basicTransition;
  logForm: FormGroup;
  email: AbstractControl;
  password: AbstractControl;
  emailErrorStr = 'Enter your email';
  passwordErrorStr = 'Enter your password';
  model: any = {};
  loading = false;
  loginError = false;
  loginErrorMessage = '';
  returnUrl: string;
  // tslint:disable-next-line:max-line-length
  emailPattern = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private authenticationService: AuthenticationService,
    public dialog: MatDialog
  ) {}

  ngOnInit() {
    // reset login status
    this.authenticationService.logout();

    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    // form declaration
    this.logForm = this.fb.group({
      email: [
        '',
        Validators.compose([
          Validators.required,
          Validators.pattern(this.emailPattern)
        ])
      ],
      password: [
        '',
        Validators.compose([Validators.required, Validators.minLength(5)])
      ]
    });
    // connecting controls with form inputs
    this.email = this.logForm.controls['email'];
    this.password = this.logForm.controls['password'];
  }

  onSubmit(form: NgForm) {
    // showing possible errors
    this.email.markAsTouched();
    this.password.markAsTouched();
    if (!form.valid) {
    } else {
      this.loading = true;
      this.authenticationService
        // login with credentials from form
        .login(this.email.value, this.password.value)
        .subscribe(
          data => {
            // if login is successful redirect to previous url if was, if not go to /
            this.router.navigate([this.returnUrl]);
          },
          error => {
            // set error message from api to loginErrorMessage
            this.loginError = true;
            console.log(error);
            this.loginErrorMessage = 'Email or password is incorrect';
            this.loading = false;
          }
        );
    }
  }

  /**
   * Handle error in template and add appropriate error message.
   *
   * @param {AbstractControl} control Control from template
   * @returns {boolean} Returns true if error occurs and is ready to display.
   * @memberof LoginComponent
   */
  inputError(control: AbstractControl): boolean {
    let errorStr: string;
    let controlName: string;
    // retrieve controls names into array to show errors for user
    const parent = control['_parent'];
    if (parent instanceof FormGroup) {
      Object.keys(parent.controls).forEach(name => {
        if (control === parent.controls[name]) {
          controlName = name;
        }
      });
    }
    if (control.errors !== null && control.touched) {
      if (control.value.length === 0) {
        errorStr = 'Enter your ' + controlName;
      } else {
        errorStr = 'Enter valid ' + controlName;
      }
      switch (controlName) {
        case 'email':
          this.emailErrorStr = errorStr;
          break;
        case 'password':
          this.passwordErrorStr = errorStr;
          break;
      }
      return true;
    }
  }

  /**
   * Show dialog to recover password and show message about send new password.
   *
   * @memberof LoginComponent
   */
  runPasswordRecovery() {
    const dialogRef = this.dialog.open(PasswordRecoveryComponent, {
      data: { email: this.email.value }
    });

    // dialogRef.afterClosed().subscribe(mailToReset => {
    //   if (mailToReset) {
    //     this.dialog.open(InfoDialogComponent, {
    //       data: { message: 'New password has been sent on ' + mailToReset }
    //     });
    //   }
    // });
  }
}
