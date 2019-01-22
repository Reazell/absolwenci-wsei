
import {
  Component,
  EventEmitter,
  Inject,
  Input,
  OnInit,
  Optional,
  Output
} from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  Validators
} from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material';
import { SharedService } from '../../../../../../../services/shared.service';
import { Select, Value } from './../../../../../survey-container/models/survey-creator.models';
import { UserService } from './../../../../../survey-container/services/user.services';

@Component({
  selector: 'app-add-group-tab',
  templateUrl: './add-group-tab.component.html',
  styleUrls: ['./add-group-tab.component.scss']
})
export class AddGroupTabComponent implements OnInit {

  dialogForm: FormGroup;
  @Input()
  loader: boolean;
  @Output()
  submit: EventEmitter<FormGroup> = new EventEmitter<FormGroup>();
  selectedGroup: AbstractControl;

  groupSelectErrorString: string;
  // tslint:disable-next-line:max-line-length
  groupPattern = /^([a-zA-ZąęćłóśźżĄĘĆŁÓŚŹŻ\\']){0,}$/;
  constructor(
    private fb: FormBuilder,
    private sharedService: SharedService,
    private userService: UserService,
    @Optional()
    @Inject(MAT_DIALOG_DATA)
    public data: any
  ) {}

  groups$: object;
  ngOnInit() {
    this.getGroups();
    this.setForm();
    // console.log(this.data);
    if (this.data) {
      // console.log('dd');
      this.setValues();
    }
  }
  getGroups() {
    this.userService.getGroups().subscribe(data => this.groups$ = data);
  }

  setForm() {
    this.dialogForm = this.fb.group({
      selectedGroup: [
        '',
        Validators.compose([Validators.required, Validators.minLength(3)])
      ],
    });
    this.selectedGroup = this.dialogForm.controls['selectedGroup'];
  }
  setValues() {
    this.selectedGroup.setValue(this.data.selectedGroup);
  }

  onGroupSubmit(dialog) {
    this.submit.emit(dialog);
    console.log( 'dialog: ' + dialog.selectedGroup);
  }
  inputError(control: AbstractControl): boolean {
    // get error message and control name in string
    const errorObj = this.sharedService.inputError(control);

    // assign error to input
    if (errorObj) {
      switch (errorObj.controlName) {
        case 'selectedGroup':
          this.groupSelectErrorString = errorObj.errorStr;
          break;
      }
      return true;
    }
  }
}
