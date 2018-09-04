import { Component, OnInit } from '@angular/core';
import {
  FormGroup,
  FormBuilder,
  FormArray
} from '../../../../../node_modules/@angular/forms';

@Component({
  selector: 'app-pooling-creator',
  templateUrl: './pooling-creator.component.html',
  styleUrls: ['./pooling-creator.component.scss']
})
export class PoolingCreatorComponent implements OnInit {
  invoiceForm: FormGroup;
  default = 'dropdown-menu';
  selects: Select[] = [
    {
      control: [
        { value: 'short-answer', viewValue: 'Krótka odpowiedź' },
        { value: 'long-answer', viewValue: 'Długa odpowiedź' }
      ]
    },
    {
      control: [
        { value: 'single-choice', viewValue: 'Jednokrotny wybór' },
        { value: 'multiple-choice', viewValue: 'Wielokrotny wybór' }
      ]
    },
    {
      control: [
        { value: 'dropdown-menu', viewValue: 'Menu rozwijane' },
        { value: 'linear-scale', viewValue: 'Skala liniowa' }
      ]
    },
    {
      control: [
        {
          value: 'single-selection-grid',
          viewValue: 'Siatka jednokrotnego wyboru'
        },
        {
          value: 'multiple-selection-grid',
          viewValue: 'Siatka wielokrotnego wyboru'
        }
      ]
    }
  ];

  minValue: Value[] = [{ value: 0 }, { value: 1 }];
  maxValue: Value[] = [
    { value: 2 },
    { value: 3 },
    { value: 4 },
    { value: 5 },
    { value: 6 },
    { value: 7 },
    { value: 8 },
    { value: 9 },
    { value: 10 }
  ];
  info = {
    add: 'Dodaj pytanie',
    copy: 'Duplikuj',
    delete: 'Usuń pytanie'
  };

  constructor(private fb: FormBuilder) {}

  ngOnInit() {
    this.invoiceForm = this.fb.group({
      Form_Title: ['Formularz bez nazwy'],
      QuestionData: this.fb.array([this.addRows()])
    });
  }

  addRows() {
    const group = this.fb.group({
      question: [''],
      select: [this.default],
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
    console.log(questionArr.controls.length);
    if (questionArr.controls.length > 1) {
      questionArr.removeAt(index);
    } else {
      questionArr.removeAt(0);
      questionArr.push(this.addRows());
    }
  }

  addGroup(FieldData, select: string) {
    let group;
    switch (select) {
      case 'short-answer':
        group = this.addInput();
        FieldData.push(group);
        break;
      case 'long-answer':
        group = this.addInput();
        FieldData.push(group);
        break;
      case 'dropdown-menu':
        group = this.addMenu();
        FieldData.push(group);
        this.addField(select, group.controls.dropdown_menu);
        break;
      case 'linear-scale':
        group = this.addLinearScale();
        FieldData.push(group);
        this.addField(select, group.controls.linear_scale);
        break;
      case 'single-choice':
        group = this.addSingleChoice();
        FieldData.push(group);
        this.addField(select, group.controls.single_choice);
        break;
      case 'multiple-choice':
        group = this.addMultipleChoice();
        FieldData.push(group);
        this.addField(select, group.controls.multiple_choice);
        break;
      case 'single-selection-grid':
        group = this.addSingleSelectionGrid();
        FieldData.push(group);
        this.addField(select, group.controls.columns, group.controls.rows);
        break;
      case 'multiple-selection-grid':
        group = this.addSingleSelectionGrid();
        FieldData.push(group);
        this.addField(select, group.controls.columns, group.controls.rows);
        break;
    }
  }
  addField(select: string, choiceData, choiceData2?) {
    switch (select) {
      case 'dropdown-menu':
        this.addSelectOption(choiceData);
        break;
      case 'linear-scale':
        this.addLinearScaleField(choiceData);
        break;
      case 'single-choice':
        this.addSingleMultipleField(choiceData);
        break;
      case 'multiple-choice':
        this.addSingleMultipleField(choiceData);
        break;
      case 'single-selection-grid':
        this.addSingleSelectionField(choiceData);
        this.addSingleSelectionInput(choiceData2);
        break;
      case 'multiple-selection-grid':
        this.addSingleSelectionField(choiceData);
        this.addSingleSelectionInput(choiceData2);
        break;
    }
  }

  addInput() {
    const group = this.fb.group({
      input: [{ value: '', disabled: true }]
    });
    return group;
  }
  addLinearScale() {
    const group = this.fb.group({
      linear_scale: this.fb.array([])
    });
    return group;
  }
  addSingleChoice() {
    const group = this.fb.group({
      single_choice: this.fb.array([])
    });
    return group;
  }
  addMultipleChoice() {
    const group = this.fb.group({
      multiple_choice: this.fb.array([])
    });
    return group;
  }
  addMenu() {
    const group = this.fb.group({
      dropdown_menu: this.fb.array([])
    });
    return group;
  }
  addSingleSelectionGrid() {
    const group = this.fb.group({
      columns: this.fb.array([]),
      rows: this.fb.array([])
    });
    return group;
  }
  addLinearScaleField(choiceArr) {
    const group = this.fb.group({
      minValue: 1,
      maxValue: 6,
      minLabel: [''],
      maxLabel: ['']
    });
    choiceArr.push(group);
  }
  addSelectOption(choiceArr) {
    const length = choiceArr.controls.length;
    const group = this.fb.group({
      input: 'opcja ' + length
    });
    choiceArr.push(group);
  }
  addSingleMultipleField(choiceArr) {
    const length = choiceArr.controls.length;
    const group = this.fb.group({
      value: [{ value: false, disabled: true }],
      viewValue: 'opcja ' + length
    });
    choiceArr.push(group);
  }
  addSingleSelectionField(selectionArr) {
    const length = selectionArr.controls.length;
    const group = this.fb.group({
      value: [{ value: false, disabled: true }],
      viewValue: 'kolumna ' + length
    });
    selectionArr.push(group);
  }
  addSingleSelectionInput(selectionArr) {
    const length = selectionArr.controls.length;
    const group = this.fb.group({
      input: 'wiersz ' + length
    });
    selectionArr.push(group);
  }

  removeField(index, SingleChoice) {
    SingleChoice.removeAt(index);
  }

  updateSelection(SingleChoice, choice, e) {
    if (e.source) {
      console.log(e.source.name, e);
    }
    SingleChoice.controls.forEach(el => {
      el.controls.value.setValue(false);
    });
    choice.controls.value.setValue(true);
    e.source.checked = true;
  }

  changeControl(controls, select) {
    controls.removeAt(0);
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
export class Select {
  control: Control[];
  constructor(control: Control[]) {
    this.control = control;
  }
}

export class Value {
  value: number;
  constructor(value: number) {
    this.value = value;
  }
}
