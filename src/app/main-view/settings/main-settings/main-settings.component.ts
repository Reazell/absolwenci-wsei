import { UserService } from './../../../auth/services/user.service';
import { Router } from '@angular/router';
import {
  FormBuilder,
  Validators,
  AbstractControl,
  NgForm,
  FormGroup,
  FormControl
} from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { SharedService } from '../../../services/shared.service';
@Component({
  selector: 'app-main-settings',
  templateUrl: './main-settings.component.html',
  styleUrls: ['./main-settings.component.scss']
})
export class MainSettingsComponent implements OnInit {
  panelOpenState = false;

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

  userInfo = {
    id: 2,
    name: 'Gabriela',
    surname: 'Oskroba',
    email: 'gabi97_97@o2.pl',
    phoneNum: '+48123123123',
    albumID: '10610',
    companyName: 'QVC',
    location: 'Kraków',
    companyDescription: ''
  };

  profileType: string;

  // user object sent to API
  user: any = {};
  // loader
  loading = false;
  // profiles tooltip
  profiles = [
    { value: 'Student', icon: 'pen', message: 'Student' },
    {
      value: 'Graduate',
      icon: 'graduation-cap',
      message: 'Absolwent'
    },
    { value: 'Employer', icon: 'briefcase', message: 'Pracodawca' }
  ];

  // tslint:disable-next-line:max-line-length
  emailPattern = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
  namePattern = /^([a-zA-ZąęćłóśźżĄĘĆŁÓŚŹŻ\\']){0,}$/;
  surnamePattern = /^([a-zA-ZąęćłóśźżĄĘĆŁÓŚŹŻ]+[\s\-\\'])*[a-zA-ZąęćłóśźżĄĘĆŁÓŚŹŻ]+$/;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private userService: UserService,
    private sharedService: SharedService
  ) {
    this.getProfileType();
  }

  ngOnInit() {
    // form declaration
    this.regForm = this.fb.group({
      name: [
        this.userInfo.name,
        Validators.compose([
          Validators.required,
          Validators.pattern(this.namePattern)
        ])
      ],
      lastName: [
        this.userInfo.surname,
        Validators.compose([
          Validators.required,
          Validators.pattern(this.surnamePattern)
        ])
      ],
      email: [
        this.userInfo.email,
        Validators.compose([
          Validators.required,
          Validators.pattern(this.emailPattern)
        ])
      ],
      profileName: [this.profileType, Validators.required],
      phoneNum: [this.userInfo.phoneNum, Validators.required]
    });

    // connecting controls with form inputs
    this.setAdditionalControls();
    this.name = this.regForm.controls['name'];
    this.lastName = this.regForm.controls['lastName'];
    this.email = this.regForm.controls['email'];
    this.password = this.regForm.controls['password'];
    this.passwordConfirm = this.regForm.controls['passwordConfirm'];
    this.profileName = this.regForm.controls['profileName'];
    this.phoneNum = this.regForm.controls['phoneNum'];
  }

  getProfileType() {
    this.profileType = JSON.parse(localStorage.getItem('currentUser')).role;
    // console.log(this.profileType);
  }

  setAdditionalControls() {
    if (this.profileType === 'student') {
      this.regForm.addControl(
        'albumID',
        new FormControl(this.userInfo.albumID, Validators.required)
      );
      this.albumID = this.regForm.controls['albumID'];
    } else if (this.profileType === 'employer') {
      this.regForm.addControl(
        'companyName',
        new FormControl(this.userInfo.companyName, Validators.required)
      );
      this.regForm.addControl(
        'location',
        new FormControl(this.userInfo.location, Validators.required)
      );
      this.regForm.addControl(
        'companyDescription',
        new FormControl(this.userInfo.companyDescription)
      );
      this.companyName = this.regForm.controls['companyName'];
      this.location = this.regForm.controls['location'];
      this.companyDescription = this.regForm.controls['companyDescription'];
    }
  }
  onSubmit(form: NgForm): void {
    if (!form.valid) {
      console.log('not valid');
    } else {
      this.loading = true;
      this.createUser();
      console.log(this.user);
      this.userService.updateProfile(this.user).subscribe(
        data => {
          console.log(data);
        },
        error => {
          console.log(error);
        }
      );
    }
  }

  createUser(): void {
    this.user.id = this.userInfo.id;
    this.user.name = this.name.value;
    this.user.surname = this.lastName.value;
    this.user.email = this.email.value;
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
        case 'albumID':
          this.albumIDErrorStr = errorObj.errorStr;
          break;
        case 'phone number':
          this.phoneNumErrorStr = errorObj.errorStr;
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
    this.registrationError = false;
  }

  onBlur(control: AbstractControl): void {
    // hide possible errors
    if (control.dirty === false) {
      control.markAsUntouched();
      this.registrationError = false;
    }
  }
}
