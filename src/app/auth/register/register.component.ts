import { UserService } from '../services/user.service';
import { Component, OnInit, OnDestroy } from '@angular/core';
import {
  FormGroup,
  NgForm,
  FormBuilder,
  Validators,
  AbstractControl
} from '@angular/forms';
import { Router } from '@angular/router';
import { SharedService } from '../../services/shared.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
  // animations: [profilesTransition]
})
export class RegisterComponent implements OnInit, OnDestroy {
  // @HostBinding('@profilesTransition')
  // profilesTransition;

  // declare form
  regForm: FormGroup;
  name: AbstractControl;
  lastName: AbstractControl;
  email: AbstractControl;
  password: AbstractControl;
  passwordConfirm: AbstractControl;
  profileName: AbstractControl;
  albumID: AbstractControl;
  phoneNum: AbstractControl;
  companyName: AbstractControl;
  location: AbstractControl;
  companyDescription: AbstractControl;

  // error handlers
  nameErrorStr: string;
  lastNameErrorStr: string;
  countryErrorStr: string;
  emailErrorStr: string;
  passwordErrorStr: string;
  passwordConfirmErrorStr: string;
  albumIDErrorStr: string;
  phoneNumErrorStr: string;
  companyNameErrorStr: string;
  locationErrorStr: string;
  companyDescriptionErrorStr: string;
  registrationError = false;
  registrationErrorMessage: Array<string>;

  // user object sent to API
  user: any = {};
  // loader
  loading = false;
  // profiles tooltip
  profiles = [
    { value: 'Student', message: 'Student' },
    {
      value: 'Graduate',
      message: 'Absolwent'
    },
    { value: 'Employer', message: 'Pracodawca' }
  ];

  // tslint:disable-next-line:max-line-length
  emailPattern = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
  passwordPattern = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}/;
  namePattern = /^([a-zA-ZąęćłóśźżĄĘĆŁÓŚŹŻ\\']){0,}$/;
  surnamePattern = /^([a-zA-ZąęćłóśźżĄĘĆŁÓŚŹŻ]+[\s\-\\'])*[a-zA-ZąęćłóśźżĄĘĆŁÓŚŹŻ]+$/;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private userService: UserService,
    private sharedService: SharedService
  ) {}

  ngOnDestroy() {
    this.sharedService.deleteControlArray();
  }
  ngOnInit() {
    // reset login status
    if (localStorage.getItem('currentUser')) {
      this.router.navigateByUrl('');
    }

    // form declaration
    this.regForm = this.fb.group({
      name: [
        '',
        Validators.compose([
          Validators.required,
          Validators.pattern(this.namePattern)
        ])
      ],
      lastName: [
        '',
        Validators.compose([
          Validators.required,
          Validators.pattern(this.surnamePattern)
        ])
      ],
      email: [
        '',
        Validators.compose([
          Validators.required,
          Validators.pattern(this.emailPattern)
        ])
      ],
      password: [
        '',
        Validators.compose([
          Validators.required,
          Validators.pattern(this.passwordPattern)
        ])
      ],
      passwordConfirm: [
        '',
        Validators.compose([Validators.required, this.matchPassword])
      ],
      profileName: ['Student', Validators.required],
      albumID: ['', Validators.required],
      phoneNum: ['', Validators.required],
      companyName: [''],
      location: [''],
      companyDescription: ['']
    });

    // connecting controls with form inputs
    this.name = this.regForm.controls['name'];
    this.lastName = this.regForm.controls['lastName'];
    this.email = this.regForm.controls['email'];
    this.password = this.regForm.controls['password'];
    this.passwordConfirm = this.regForm.controls['passwordConfirm'];
    this.profileName = this.regForm.controls['profileName'];
    this.albumID = this.regForm.controls['albumID'];
    this.phoneNum = this.regForm.controls['phoneNum'];
    this.companyName = this.regForm.controls['companyName'];
    this.location = this.regForm.controls['location'];
    this.companyDescription = this.regForm.controls['companyDescription'];
  }

  onSubmit(form: NgForm): void {
    if (!form.valid) {
      // showing possible errors
      this.setAllAsTouched();
    } else {
      this.loading = true;
      this.createUser();
      // create new user
      switch (this.profileName.value) {
        case 'Student':
          this.userService.createStudent(this.user).subscribe(
            data => {
              this.router.navigateByUrl('/auth/login');
            },
            error => {
              this.loading = false;
              this.registrationError = true;
              // set error message from api to loginErrorMessage
              console.log(error);
              this.registrationErrorMessage = error;
            }
          );
          break;
        case 'Employer':
          this.userService.createEmployer(this.user).subscribe(
            data => {
              this.router.navigateByUrl('/auth/login');
            },
            error => {
              this.loading = false;
              this.registrationError = true;
              // set error message from api to loginErrorMessage
              this.registrationErrorMessage = error.error;
            }
          );
          break;
        case 'Graduate':
          this.userService.createGraduate(this.user).subscribe(
            data => {
              this.router.navigateByUrl('/auth/login');
            },
            error => {
              this.loading = false;
              this.registrationError = true;
              // set error message from api to loginErrorMessage
              this.registrationErrorMessage = error;
            }
          );
          break;
      }
    }
  }

  createUser(): void {
    this.user.firstName = this.name.value;
    this.user.lastName = this.lastName.value;
    this.user.email = this.email.value;
    this.user.password = this.password.value;
    this.user.profileName = this.profileName.value;
    this.user.phoneNum = this.phoneNum.value;

    switch (this.profileName.value) {
      case 'Student':
        this.user.albumID = this.albumID.value;
        break;
      case 'Employer':
        this.user.companyName = this.companyName.value;
        this.user.location = this.location.value;
        this.user.companyDescription = this.companyDescription.value;
        break;
    }
  }

  setAllAsTouched(): void {
    this.name.markAsTouched();
    this.lastName.markAsTouched();
    this.email.markAsTouched();
    this.password.markAsTouched();
    this.passwordConfirm.markAsTouched();
    this.albumID.markAsTouched();
  }

  onFocus(control: AbstractControl): void {
    // hide possible errors
    if (control.touched) {
      control.markAsUntouched();
    }
    this.registrationError = false;
  }

  onBlur(control: AbstractControl): void {
    // hide possible errors
    if (control.dirty === false) {
      control.markAsUntouched();
      this.registrationError = false;
    }
  }

  clearPasswordConfirm(): void {
    // clear confirm password input after changing password input
    this.passwordConfirm.setValue('');
    this.passwordConfirm.markAsUntouched();
  }

  matchPassword(control: AbstractControl): { [s: string]: boolean } {
    // check if inputs have same values
    if (control.parent !== undefined) {
      const password = control.parent.get('password').value;
      const passwordConfirm = control.parent.get('passwordConfirm').value;
      if (password !== passwordConfirm) {
        return { noMatch: true };
      }
    }
  }

  inputError(control: AbstractControl): boolean {
    // get error message and control name in string
    const errorObj = this.sharedService.inputError(control);

    // assign error to input
    if (errorObj) {
      switch (errorObj.controlName) {
        case 'name':
          this.nameErrorStr = errorObj.errorStr;
          break;
        case 'last name':
          this.lastNameErrorStr = errorObj.errorStr;
          break;
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

  passwordNoMatch(control: AbstractControl): boolean {
    /*show error while passwords do not match*/
    if (this.password.value.length === 0) {
      this.passwordConfirmErrorStr = 'This input cannot be empty';
    } else if (this.passwordConfirm.errors) {
      if (this.passwordConfirm.errors.noMatch === undefined) {
        this.passwordConfirmErrorStr = 'Passwords do not match';
        return true;
      }
    } else {
      return false;
    }
  }
}
