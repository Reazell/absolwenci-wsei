import { Component, OnInit } from '@angular/core';
import {
  FormGroup,
  FormBuilder,
  AbstractControl,
  Validators
} from '@angular/forms';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-password-recovery',
  templateUrl: './password-recovery.component.html',
  styleUrls: ['./password-recovery.component.scss']
})
export class PasswordRecoveryComponent implements OnInit {
  loading = false;
  mail: string;
  passForm: FormGroup;
  email: AbstractControl;
  emailErrorStr: string;
  // tslint:disable-next-line:max-line-length
  emailPattern = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

  constructor(private fb: FormBuilder, private userService: UserService) {}

  ngOnInit() {
    this.mail = this.userService.getMailData();
    this.passForm = this.fb.group({
      email: [
        this.mail,
        Validators.compose([
          Validators.required,
          Validators.pattern(this.emailPattern)
        ])
      ]
    });
    this.email = this.passForm.controls['email'];
  }

  onSubmit() {
    // this.userService.sendRestorePasswordEmail(this.email.value).subscribe(
    //   data => {
    //     this.dialogRef.close(this.email.value);
    //   },
    //   error => {
    //     console.log(error);
    //     this.dialogRef.close(false);
    //   }
    // );
  }

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
      }
      return true;
    }
  }
}
