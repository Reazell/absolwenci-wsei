import { profilesTransition } from '../other/profiles.animations';
import { UserService } from '../services/user.service';
import {
  Component,
  OnInit,
  HostBinding,
  OnChanges,
  OnDestroy
} from '@angular/core';
import {
  FormGroup,
  NgForm,
  FormBuilder,
  Validators,
  AbstractControl
} from '@angular/forms';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
  // animations: [profilesTransition]
})
export class RegisterComponent implements OnInit, OnDestroy {
  // @HostBinding('@profilesTransition')
  expand;
  profilesTransition;
  regForm: FormGroup;
  name: AbstractControl;
  lastName: AbstractControl;
  email: AbstractControl;
  password: AbstractControl;
  passwordConfirm: AbstractControl;
  profileName: AbstractControl;
  albumID: AbstractControl;

  nameErrorStr: string;
  lastNameErrorStr: string;
  countryErrorStr: string;
  emailErrorStr: string;
  passwordErrorStr: string;
  passwordConfirmErrorStr: string;
  albumIDErrorStr: string;

  user: any = {};
  loading = false;
  registrationError = false;
  registrationErrorMessage: Array<string>;

  profiles = [
    { value: 'Student', message: 'Student' },
    {
      value: 'Graduate',
      message: 'Absolwent'
    },
    { value: 'Employer', message: 'Pracodawca' }
    // { value: 'Company', message: 'Pick if you represent company.' }
  ];

  // tslint:disable-next-line:max-line-length
  emailPattern = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
  passwordPattern = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}/;
  namePattern = /^([a-zA-ZąęćłóśźżĄĘĆŁÓŚŹŻ\\']){0,}$/;
  surnamePattern = /^([a-zA-ZąęćłóśźżĄĘĆŁÓŚŹŻ]+[\s\-\\'])*[a-zA-ZąęćłóśźżĄĘĆŁÓŚŹŻ]+$/;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    public dialog: MatDialog,
    private userService: UserService
  ) {}

  ngOnDestroy() {
    // this.loading = true;
  }
  ngOnInit() {
    // this.updateHeight();
    // reset login status
    if (localStorage.getItem('currentUser')) {
      this.router.navigateByUrl('');
    }

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
      albumID: ['', Validators.required]
    });
    // connecting controls with form inputs
    this.name = this.regForm.controls['name'];
    this.lastName = this.regForm.controls['lastName'];
    this.email = this.regForm.controls['email'];
    this.password = this.regForm.controls['password'];
    this.passwordConfirm = this.regForm.controls['passwordConfirm'];
    this.profileName = this.regForm.controls['profileName'];
    this.albumID = this.regForm.controls['albumID'];
  }

  // updateHeight() {
  //   const el = this.expand.nativeElement;
  //     const prevHeight = el.style.height;
  //     el.style.height = 'auto';
  //     const newHeight = el.scrollHeight + 100 + 'px';
  //     el.style.height = prevHeight;
  //     console.log(newHeight);
  //       el.style.height = newHeight;
  // }

  /**
   * Method to get all values from form, make request and handle result.
   * If error occurs display error message and if success redirect to login page.
   *
   * @param {NgForm} form Form with direct values from template.
   * @memberof LoginComponent
   */
  onSubmit(form: NgForm) {
    if (!form.valid) {
      // showing possible errors
      this.name.markAsTouched();
      this.lastName.markAsTouched();
      this.email.markAsTouched();
      this.password.markAsTouched();
      this.passwordConfirm.markAsTouched();
      this.albumID.markAsTouched();
    } else {
      this.loading = true;
      this.user.firstName = this.name.value;
      this.user.lastName = this.lastName.value;
      this.user.email = this.email.value;
      this.user.password = this.password.value;
      this.user.profileName = this.profileName.value;
      this.user.albumID = this.albumID.value;
      // create new user
      this.userService.create(this.user).subscribe(
        data => {
          //  this.showActivationInfo(true);
          this.router.navigateByUrl('/auth/login');
        },
        error => {
          this.loading = false;
          this.registrationError = true;
        }
      );
    }
  }

  onFocus(control: AbstractControl) {
    /*hide possible errors*/
    if (control.touched) {
      control.markAsUntouched();
    }
    this.registrationError = false;
  }
  onBlur(control: AbstractControl) {
    if (control.dirty === false) {
      control.markAsUntouched();
      this.registrationError = false;
    }
  }

  clearPasswordConfirm() {
    /*clear confirm password input after changing password input*/
    this.passwordConfirm.setValue('');
    this.passwordConfirm.markAsUntouched();
  }

  matchPassword(control: AbstractControl): { [s: string]: boolean } {
    /*check if inputs have same values*/
    if (control.parent !== undefined) {
      const password = control.parent.get('password').value;
      const passwordConfirm = control.parent.get('passwordConfirm').value;
      if (password !== passwordConfirm) {
        return { noMatch: true };
      }
    }
  }

  inputError(control: AbstractControl): boolean {
    let errorStr: string;
    let controlName: string;
    // retrieve controls names into array to show errors for user
    const parent = control['_parent'];
    const parentArray = Object.keys(parent.controls);
    if (parent instanceof FormGroup) {
      for (let i = 0; i < parentArray.length; i++) {
        if (control === parent.controls[parentArray[i]]) {
          controlName = parentArray[i];
          break;
        }
      }
    }
    if (control.errors !== null && control.touched) {
      if (controlName === 'lastName') {
        controlName = 'last name';
      }
      if (control.value.length === 0) {
        errorStr = 'Enter your ' + controlName;
      } else {
        if (controlName === 'password') {
          errorStr =
            // tslint:disable-next-line:max-line-length
            'Użyj co najmniej ośmiu znaków, w tym jednocześnie liter, cyfr i symboli: !#$%&?';
        } else {
          errorStr = 'Enter valid ' + controlName;
        }
      }
      switch (controlName) {
        case 'name':
          this.nameErrorStr = errorStr;
          break;
        case 'last name':
          this.lastNameErrorStr = errorStr;
          break;
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
