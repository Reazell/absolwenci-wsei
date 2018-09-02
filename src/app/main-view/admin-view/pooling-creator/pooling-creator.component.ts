import { Component, OnInit } from '@angular/core';
import {
  FormGroup,
  FormBuilder,
  FormArray,
  FormControl,
  AbstractControl
} from '../../../../../node_modules/@angular/forms';

@Component({
  selector: 'app-pooling-creator',
  templateUrl: './pooling-creator.component.html',
  styleUrls: ['./pooling-creator.component.scss']
})
export class PoolingCreatorComponent implements OnInit {
  invoiceForm: FormGroup;

  controls: Control[] = [
    // { value: 'radio', viewValue: 'radio' },
    { value: 'single-choice', viewValue: 'jednokrotny wybór' },
    { value: 'multiple-choice', viewValue: 'wielokrotny wybór' }
  ];
  singleControls = [{ value: '1', viewValue: 'opcja 1' }];

  constructor(private fb: FormBuilder) {}

  ngOnInit() {
    this.invoiceForm = this.fb.group({
      Form_Title: [''],
      QuestionData: this.fb.array([this.addRows()])
    });
  }

  addRows() {
    const group = this.fb.group({
      question: [''],
      select: ['single-choice'],
      FieldData: this.fb.array([])
    });
    this.addGroup(group.controls.FieldData, group.controls.select.value);
    return group;
  }

  addQuestion() {
    const control: FormArray = this.invoiceForm.get(
      `QuestionData`
    ) as FormArray;
    control.push(this.addRows());
  }
  removeQuestion(index) {
    const questionArr = this.invoiceForm.controls.QuestionData as FormArray;
    questionArr.removeAt(index);
  }

  addGroup(FieldData: AbstractControl, select: string) {
    // console.log(question);
    switch (select) {
      case 'single-choice':
        this.addSingleChoice(FieldData);
        break;
      case 'multiple-choice':
        this.addMultipleChoice(FieldData);
        break;
    }
    // console.log(FieldData);
  }
  addField(select: string, SingleChoice) {
    // console.log('single choice: ', SingleChoice);
    switch (select) {
      case 'single-choice':
        this.addSingleChoiceField(SingleChoice);
        break;
      case 'multiple-choice':
        // this.addMultipleChoiceField();
        break;
    }
  }

  addSingleChoice(FieldData) {
    // const group = this.fb.group({
    //   single_choice: ['']
    // });
    // FieldData.push(group);
    // this.addSingleChoiceField();
    const group = this.fb.group({
      single_choice: this.fb.array([])
    });
    FieldData.push(group);
    this.addSingleChoiceField(group.controls.single_choice);
    console.log('1: ', group.controls.single_choice);
    console.log('2: ', group.controls[0]);

    // return group;
  }
  addSingleChoiceField(SingleChoice) {
    const length = SingleChoice.controls.length;
    const group = this.fb.group({
      value: false,
      viewValue: 'opcja ' + length
    });
    SingleChoice.push(group);
  }

  addMultipleChoice(FieldData) {}
  addMultipleChoiceField() {}

  removeField(index, SingleChoice) {
    SingleChoice.removeAt(index);
  }

  updateSelection(SingleChoice, choice, e) {
    console.log(e.source.name, e);
    SingleChoice.controls.forEach(el => {
      el.controls.value.setValue(false);
    });
    choice.controls.value.setValue(true);
    e.source.checked = true;
  }

  changeControl(controls, select) {
    const length = controls.length;
    for (let i = 0; i < length; i++) {
      controls.removeAt(0);
    }
    this.addGroup(controls, select);
  }

  changeSingleValue(single, e) {
    // single.viewValue = e.target.value;
  }
}

export class Control {
  value: any;
  viewValue: string;
  constructor(value: any, viewValue: string) {
    this.value = value;
    this.viewValue = viewValue;
  }
}

// export class SingleChoice extends Control {
//   constructor() {}
// }

/*
export class PoolingCreatorComponent implements OnInit {
  myForm: FormGroup;
  control: FormGroup;
  formArr;
  // controlArr;
  arr = Array<MainForm>();
  r1: MainForm;
  r2: MainForm;
  items;

  selectedValue: string;
  controls: Control[] = [
    // { value: 'radio', viewValue: 'radio' },
    { value: 'single-choice', viewValue: 'jednokrotny wybór' },
    { value: 'multiple-choice', viewValue: 'wielokrotny wybór' }
  ];
  // checks: Control[] = [
  //   { value: 'value1', viewValue: 'pierwsza wartość' },
  //   { value: 'value2', viewValue: 'druga wartość' },
  //   { value: 'value3', viewValue: 'trzecia wartość' }
  // ];
  constructor(private fb: FormBuilder) {
    this.myForm = this.fb.group({
      formArray: this.fb.array([])
    });

    this.formArr = this.myForm.controls.formArray as FormArray;
    this.items = this.myForm.controls['formArray']['controls'];
    this.addMainForm();
  }

  ngOnInit() {}

  onSubmit(form) {
    console.log(form.value);
  }

  setControlView(index, value) {
    console.log(index, value);
  }

  addMainForm() {
    let main = new MainForm();
    const fieldArrGroup = this.initControl();
    main = {
      select: 'single-choice',
      description: '',
      field: fieldArrGroup
    };
    this.formArr.push(this.fb.group(main));
    this.addSingleChoice(fieldArrGroup);
    //

    // this.controlArr.push
    //
    this.arr.push(main);
    console.log(this.myForm);
    console.log(this.formArr);
    console.log(this.items);
    // const l = this.items[0].value;
    // console.log(l);
    // console.log(this.arr);
  }

  addSingleChoice(fieldArrGroup, index = 0) {
    let single = new SingleChoice();
    single = {
      order: '8',
      type: '9'
    };

    const fieldArr = fieldArrGroup.controls.fieldArray as FormArray;
    fieldArr.push(this.fb.group(single));
    console.log(fieldArr);
  }

  initControl() {
    return this.fb.group({
      fieldArray: this.fb.array([])
    });
  }

  changeControl(item) {
    console.log(item);
  }

  removeField(i) {
    this.formArr.removeAt(i);
  }
}

export class MainForm {
  select: string;
  description: string;
  field: FormGroup;
}
export class SingleChoice {
  order: string;
  type: string;
}
export interface Control {
  value: string;
  viewValue: string;
}
*/
