import { SharedService } from '../../services/shared.service';
import { Component, OnInit, OnDestroy } from '@angular/core';
import {
  FormGroup,
  NgForm,
  FormBuilder,
  Validators,
  AbstractControl
} from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from '../services/authentication.service';
import { UserService } from '../services/user.service';

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
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit, OnDestroy {
  // declare form
  logForm: FormGroup;
  email: AbstractControl;
  password: AbstractControl;

  // booleans
  loading = false;
  recoveryRoute = false;

  // error handlers
  emailErrorStr: string;
  passwordErrorStr: string;
  loginError = false;
  loginErrorMessage = '';

  // tslint:disable-next-line:max-line-length
  emailPattern = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private authenticationService: AuthenticationService,
    private userService: UserService,
    private sharedService: SharedService
  ) {}

  ngOnDestroy() {
    if (this.recoveryRoute === true) {
      this.userService.passMailData(this.email.value);
    }
    this.sharedService.deleteControlArray();
  }

  ngOnInit() {
    // reset login status
    this.authenticationService.logout();

    // form declaration
    this.logForm = this.fb.group({
      email: [
        '',
        Validators.compose([
          Validators.required,
          Validators.pattern(this.emailPattern)
        ])
      ],
      password: ['', Validators.compose([Validators.required])]
    });

    // connecting controls with form inputs
    this.email = this.logForm.controls['email'];
    this.password = this.logForm.controls['password'];
  }

  onSubmit(form: NgForm): void {
    if (!form.valid) {
      // showing possible errors
      this.email.markAsTouched();
      this.password.markAsTouched();
    } else {
      this.loading = true;
      this.authenticationService
        // login with credentials from form
        .login(this.email.value, this.password.value)
        .subscribe(
          data => {
            console.log(data);
            this.userService.isLogged.next(true);
            // if login is successful, redirect to app
            this.routeSwitch(data.role);
          },
          error => {
            console.log(error);
            // set error message from api to loginErrorMessage
            this.loginError = true;
            this.loginErrorMessage = 'Nieprawidłowy mail lub hasło';
            this.loading = false;
          }
        );
    }
  }
  routeSwitch(role) {
    this.sharedService.routeSwitch(role);
  }

  inputError(control: AbstractControl): boolean {
    // get error message and control name in string
    const errorObj = this.sharedService.inputError(control);

    // assign error to input
    if (errorObj) {
      switch (errorObj.controlName) {
        case 'email':
          this.emailErrorStr = errorObj.errorStr;
          break;
        case 'password':
          this.passwordErrorStr = errorObj.errorStr;
          break;
      }
      return true;
    }
  }

  setRecoveryRoute() {
    this.recoveryRoute = true;
  }
}
