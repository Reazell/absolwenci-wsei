import { Injectable } from '@angular/core';
import { AbstractControl, FormGroup } from '@angular/forms';
import { BehaviorSubject, Subject } from 'rxjs';
import { Router } from '../../../node_modules/@angular/router';

@Injectable()
export class SharedService {
  toggleSidebar: BehaviorSubject<number> = new BehaviorSubject<number>(0);
  saveButton: Subject<number> = new Subject<number>();
  sendButton: Subject<number> = new Subject<number>();
  showCreator: Subject<boolean> = new Subject<boolean>();
  showSend: Subject<boolean> = new Subject<boolean>();
  controlArray: string[];
  constructor(private router: Router) {}

  saveSurveyButton(x) {
    this.saveButton.next(x);
  }
  sendSurveyButton(x) {
    this.sendButton.next(x);
  }
  showCreatorButton(x) {
    this.showCreator.next(x);
  }
  showSendButton(x) {
    this.showSend.next(x);
  }

  routeSwitch(role) {
    switch (role) {
      case 'student':
        this.router.navigateByUrl('/app/student');
        break;
      case 'employer':
        this.router.navigateByUrl('/app/employer');
        break;
      case 'graduate':
        this.router.navigateByUrl('/app/graduate');
        break;
    }
  }

  inputError(control: AbstractControl) {
    // retrieve controls names into array to show errors for user
    const parent = control['_parent'];
    if (control.touched === true || control.dirty === true) {
      if (parent instanceof FormGroup) {
        let errorObj: { controlName: string; errorStr: string };
        let errorStr: string;
        let controlName: string;

        const controls = parent.controls;
        if (!this.controlArray) {
          this.controlArray = Object.keys(controls);
        }
        const length = this.controlArray.length;

        for (let i = 0; i < length; i++) {
          if (control === controls[this.controlArray[i]]) {
            controlName = this.controlArray[i];
            break;
          }
        }

        if (control.errors !== null && control.touched) {
          switch (controlName) {
            case 'lastName':
              controlName = 'last name';
              break;
            case 'phoneNum':
              controlName = 'phone number';
              break;
            case 'companyName':
              controlName = 'company name';
              break;
            case 'oldPassword':
              controlName = 'old password';
              break;
            case 'newPassword':
              controlName = 'new password';
              break;
          }
          if (control.value !== undefined && control.value.length === 0) {
            errorStr = 'Enter your ' + controlName;
          } else {
            if (controlName === 'password' || controlName === 'newPassword') {
              errorStr =
                // tslint:disable-next-line:max-line-length
                'Użyj co najmniej ośmiu znaków, w tym jednocześnie liter, cyfr i symboli: !#$%&?';
            } else {
              errorStr = 'Enter valid ' + controlName;
            }
          }
          errorObj = {
            errorStr: errorStr,
            controlName: controlName
          };
          return errorObj;
        }
      }
    }
  }

  deleteControlArray() {
    this.controlArray = undefined;
  }

  public toggleSideNav() {
    this.toggleSidebar.next(0);
  }
}
