import { Component, OnInit } from '@angular/core';
import { FormGroup, AbstractControl, FormBuilder, Validators } from '../../../../node_modules/@angular/forms';
import { Router } from '../../../../node_modules/@angular/router';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-restore-password',
  templateUrl: './restore-password.component.html',
  styleUrls: ['./restore-password.component.scss']
})
export class RestorePasswordComponent implements OnInit {
  passwordForm: FormGroup;
  email: AbstractControl;
  newPassword: AbstractControl;
  token: string;
  href: string[];
  passwordPattern = '^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$';
  constructor(
    private router: Router,
    private fb: FormBuilder,
    private userService: UserService
  ) {
    this.passwordForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      newPassword: [
        '',
        [
          Validators.required
          // Validators.pattern(this.passwordPattern)
        ]
      ]
    });
    this.email = this.passwordForm.controls['email'];
    this.newPassword = this.passwordForm.controls['newPassword'];
    this.href = this.router.url.split('/');
    this.token = this.href[this.href.length - 1];
  }

  onSubmit(form) {
    console.log(this.email.errors);
    console.log(this.newPassword.errors);
    console.log(form.valid);
    if (form.valid) {
      this.userService
        .changePasswordByRestoringPassword(
          this.email.value,
          this.token,
          this.newPassword.value
        )
        .subscribe(
          data => {
            console.log(data);
          },
          error => {
            console.log(error);
          }
        );
    }
  }
  ngOnInit() {}
}
