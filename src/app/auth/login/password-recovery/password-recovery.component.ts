import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import {
  FormGroup,
  FormBuilder,
  AbstractControl,
  NgForm
} from '@angular/forms';
import { UserService } from './../../services/user.service';

/**
 * Password recovery component (when user forgot password).
 *
 * @export
 * @class PasswordRecoveryComponent
 * @implements {OnInit}
 * Init form.
 *
 */
@Component({
  selector: 'app-password-recovery',
  templateUrl: './password-recovery.component.html',
  styleUrls: ['./password-recovery.component.scss']
})
export class PasswordRecoveryComponent implements OnInit {
  loading = false;
  passForm: NgForm;
  constructor(
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<PasswordRecoveryComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private userService: UserService
  ) {}

  configurationForm: FormGroup;
  email: AbstractControl;

  ngOnInit() {
    this.configurationForm = this.fb.group({
      email: [this.data.email]
    });

    this.email = this.configurationForm.controls['email'];
  }

  /**
   * Make request and handle result for password recovery.
   * On success: close dialog and take typed email for sign in.
   * On error: console log error.
   *
   * @memberof PasswordRecoveryComponent
   */
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

  /**
   * Close dialog - it takes parameter:
   * - false if there is no email to get from recovery
   * - email that is injected to login component's aprropriate input
   *
   * @memberof PasswordRecoveryComponent
   */
  closeDialog() {
    this.dialogRef.close();
  }
}
