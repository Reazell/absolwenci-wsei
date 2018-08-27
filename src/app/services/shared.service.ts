import { Injectable } from '@angular/core';
import {
  AbstractControl,
  FormGroup
} from '../../../node_modules/@angular/forms';

@Injectable()
export class SharedService {
  controlArray: string[];
  constructor() {}

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
}
