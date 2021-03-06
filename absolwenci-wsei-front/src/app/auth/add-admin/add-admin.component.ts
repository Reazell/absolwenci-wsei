import { Component, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  Validators
} from '@angular/forms';
import { UserProfile, Master } from '../other/user.model';
import { SharedService } from './../../services/shared.service';
import { AccountService } from './../services/account.service';

@Component({
  selector: 'app-add-admin',
  templateUrl: './add-admin.component.html',
  styleUrls: ['./add-admin.component.scss']
})
export class AddAdminComponent implements OnInit {
  loader = false;

  // declare form
  regForm: FormGroup;
  name: AbstractControl;
  surname: AbstractControl;
  email: AbstractControl;
  phoneNum: AbstractControl;
  password: AbstractControl;
  passwordConfirm: AbstractControl;

  // error strs
  nameErrorStr: string;
  surnameErrorStr: string;
  emailErrorStr: string;
  phoneNumErrorStr: string;

  buttonText = 'Dodaj admina';
  // tslint:disable-next-line:max-line-length
  emailPattern = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
  namePattern = /^([a-zA-ZąęćłóśźżĄĘĆŁÓŚŹŻ\\']){0,}$/;
  surnamePattern = /^([a-zA-ZąęćłóśźżĄĘĆŁÓŚŹŻ]+[\s\-\\'])*[a-zA-ZąęćłóśźżĄĘĆŁÓŚŹŻ]+$/;
  constructor(
    private fb: FormBuilder,
    private sharedService: SharedService,
    private accountService: AccountService
  ) {}

  ngOnInit() {
    this.setForm();
  }
  onSubmit(form) {
    if (!form.valid) {
    } else {
      console.log(this.regForm.value);
      console.log(this.setUser());
      this.accountService.createMaster(this.setUser()).subscribe(
        data => {
          console.log(data);
        },
        error => {
          console.log(error);
        }
      );
    }
  }
  setUser() {
    // this.user.phoneNum = phoneNumString.startsWith('+')
    // ? phoneNumString
    // : '+48' + phoneNumString;
    const user: Master = new Master();
    user.firstName = this.name.value;
    user.lastName = this.surname.value;
    user.email = this.email.value;
    user.password = this.password.value;
    const phoneNumString: string = this.phoneNum.value;
    user.phoneNum = phoneNumString.startsWith('+')
      ? phoneNumString
      : '+48' + phoneNumString;
    return user;
  }
  setForm() {
    this.regForm = this.fb.group({
      name: [
        '',
        Validators.compose([
          Validators.required,
          Validators.pattern(this.namePattern)
        ])
      ],
      surname: [
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
      phoneNum: [
        '',
        Validators.compose([Validators.required, Validators.minLength(3)])
      ]
    });
    this.name = this.regForm.controls['name'];
    this.surname = this.regForm.controls['surname'];
    this.email = this.regForm.controls['email'];
    this.phoneNum = this.regForm.controls['phoneNum'];
    this.password = this.regForm.controls['password'];
    this.passwordConfirm = this.regForm.controls['passwordConfirm'];
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
        case 'surname':
          this.surnameErrorStr = errorObj.errorStr;
          break;
        case 'email':
          this.emailErrorStr = errorObj.errorStr;
          break;
        case 'phoneNum':
          this.phoneNumErrorStr = errorObj.errorStr;
          break;
      }
      return true;
    }
  }
}
