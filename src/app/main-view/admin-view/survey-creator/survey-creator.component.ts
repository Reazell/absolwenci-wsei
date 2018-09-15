import { SharedService } from './../../../services/shared.service';
import { Router, NavigationEnd } from '@angular/router';
import { SurveyService } from '../../services/survey.services';
import {
  Component,
  OnInit,
  ViewChildren,
  QueryList,
  OnDestroy
} from '@angular/core';
import { FormGroup, FormBuilder, FormArray } from '@angular/forms';
import * as cloneDeep from 'lodash/cloneDeep';

@Component({
  selector: 'app-survey-creator',
  templateUrl: './survey-creator.component.html',
  styleUrls: ['./survey-creator.component.scss']
})
export class SurveyCreatorComponent implements OnInit, OnDestroy {
  @ViewChildren('inputs')
  inputs: QueryList<any>;
  @ViewChildren('inputs2')
  inputs2: QueryList<any>;

  invoiceForm: FormGroup;
  default = 'multiple-choice';
  disabled = true;
  index = 0;
  questionIndex = 0;

  // subs
  saveSurveySub: any;
  createSurveySub: any;

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
          value: 'single-grid',
          viewValue: 'Siatka jednokrotnego wyboru'
        },
        {
          value: 'multiple-grid',
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

  // sort(sortableList, event: SortEvent) {
  //   if (this.index === 0) {
  //     // console.log(sortableList);
  //     // console.log(event);
  //     const current = sortableList[event.currentIndex];
  //     const swapWith = sortableList[event.newIndex];

  //     sortableList[event.newIndex] = current;
  //     sortableList[event.currentIndex] = swapWith;
  //     this.index++;
  //   } else {
  //     this.index = 0;
  //   }
  // }
  //



  constructor(
    private fb: FormBuilder,
    private surveyService: SurveyService,
    private sharedService: SharedService,
    private router: Router
  ) {}

  ngOnInit() {
    this.invoiceForm = this.fb.group({
      Form_Title: ['Formularz bez nazwy'],
      Created_Date: [new Date().toLocaleDateString()],
      Created_Time: [new Date().toLocaleTimeString()],
      QuestionData: this.fb.array([this.addRows(-1)])
    });
    // this.createSurvey();
    this.saveSurvey();
    this.sharedService.showCreatorButton(true);
  }
  saveSurvey() {
    this.saveSurveySub = this.sharedService.saveButton.subscribe(() => {
      this.onSubmit();
    });
  }
  createSurvey() {
    this.createSurveySub = this.surveyService.createSurvey().subscribe(() => {
      console.log('created');
    });
  }
  ngOnDestroy() {
    // this.createSurveySub.unsubscribe();
    this.saveSurveySub.unsubscribe();
    this.sharedService.showCreatorButton(false);
  }

  onSubmit() {
    console.log(JSON.stringify(this.invoiceForm.getRawValue()));
    console.log(this.invoiceForm.getRawValue());

    // this.saveInLocalStorage();
    this.surveyService.saveSurvey(this.invoiceForm.getRawValue());
    this.router.navigateByUrl(`/app/admin/viewform`);
    // window.open('http://localhost:4200/app/admin/viewform', '_blank');
  }

  saveInLocalStorage() {
    const array = JSON.parse(localStorage.getItem('surveys')) || [];
    array.push(this.invoiceForm.getRawValue());
    localStorage.setItem('surveys', JSON.stringify(array));
  }
  addRows(i) {
    const group = this.fb.group({
      question: [''],
      select: [this.default],
      lastSelect: [undefined],
      QuestionPosition: i + 1,
      FieldData: this.fb.array([])
    });
    this.addGroup(group.controls.FieldData, group.controls.select.value);
    return group;
  }

  addQuestion(i) {
    const questionData: FormArray = this.invoiceForm.get(
      `QuestionData`
    ) as FormArray;
    const length = questionData.controls.length - 1;
    questionData.push(this.addRows(length));
  }
  copyQuestion(question, index) {
    const sortableList = this.invoiceForm.controls.QuestionData as FormArray;
    const length = sortableList.length;
    const clonedObject = cloneDeep(question);
    const newIndex = index + 1;
    if (index !== length - 1) {
      const questionList = sortableList.controls;
      for (let i = newIndex; i < length; i++) {
        questionList[newIndex]['controls'].QuestionPosition.setValue(i + 1);
      }
    }
    clonedObject.controls.QuestionPosition.setValue(newIndex);
    sortableList.insert(newIndex, clonedObject);
  }
  removeQuestion(i) {
    const questionArr = this.invoiceForm.controls.QuestionData as FormArray;
    const length = questionArr.controls.length;
    if (questionArr.controls.length > 1) {
      questionArr.removeAt(i);
      if (i !== length - 1) {
        this.setCurrentQuestionPositions(i, questionArr.controls, length - 1);
      }
    } else {
      questionArr.removeAt(0);
      questionArr.push(this.addRows(-1));
    }
  }
  setCurrentQuestionPositions(index, array, length) {
    for (let i = index; i < length; i++) {
      array[i].controls.QuestionPosition.setValue(i);
    }
  }

  addGroup(FieldData, select: string) {
    switch (select) {
      case 'short-answer':
      case 'long-answer':
        this.addInput(FieldData);
        break;
      case 'linear-scale':
        this.addLinearScaleField(FieldData);
        break;
      case 'dropdown-menu':
      case 'single-choice':
      case 'multiple-choice':
        // this.addCheckField(FieldData, 'opcja');
        this.addArray(FieldData);
        break;
      case 'single-grid':
      case 'multiple-grid':
        this.addSelectionGridField(FieldData);
        break;
    }
  }
  addArray(FieldData) {
    const group = this.fb.group({
      choiceOptions: this.fb.array([])
    });
    FieldData.push(group);
    this.addCheckField(group.controls.choiceOptions, 'opcja');
  }
  addInput(FieldData) {
    const group = this.fb.group({
      input: [{ value: '', disabled: this.disabled }]
    });
    FieldData.push(group);
  }
  addSelectionGridField(FieldData) {
    const group = this.fb.group({
      columns: this.fb.array([]),
      rows: this.fb.array([])
    });
    FieldData.push(group);
    this.addField(group.controls.columns, group.controls.rows);
  }

  addField(choiceData, choiceData2) {
    this.addCheckField(choiceData, 'kolumna');
    this.addInputOption(choiceData2, 'wiersz');
  }

  addLinearScaleField(choiceArr) {
    const group = this.fb.group({
      minValue: 1,
      maxValue: 5,
      minLabel: [''],
      maxLabel: ['']
    });
    choiceArr.push(group);
  }
  addInputOption(selectArr, name) {
    const length = selectArr.controls.length;
    const group = this.fb.group({
      RowPosition: length,
      input: `${name} ${length + 1}`
    });
    selectArr.push(group);
    this.autofocusField(this.inputs2, length);
  }
  addCheckField(selectArr, name) {
    const length = selectArr.controls.length;
    const group = this.fb.group({
      value: [{ value: false, disabled: this.disabled }],
      viewValue: `${name} ${length + 1}`,
      ChoicePosition: length
    });
    selectArr.push(group);
    this.autofocusField(this.inputs);
  }

  autofocusField(inputs, i?) {
    setTimeout(() => {
      if (inputs && inputs.last) {
        if (!i) {
          inputs.last.nativeElement.focus();
        } else {
          inputs.toArray()[i].nativeElement.focus();
        }
      }
    }, 0);
  }

  removeField(index, FieldData, row?) {
    const length = FieldData.controls.length - 1;
    FieldData.removeAt(index);
    if (index !== length) {
      this.setCurrentFieldPositions(index, FieldData.controls, length, row);
    }
  }
  setCurrentFieldPositions(index, arr, length, row?) {
    {
      if (!row) {
        for (let i = index; i < length; i++) {
          arr[i].controls.ChoicePosition.setValue(i);
        }
      } else {
        for (let i = index; i < length; i++) {
          arr[i].controls.RowPosition.setValue(i);
        }
      }
    }
  }

  updateSelection(SingleChoice, choice, e) {
    SingleChoice.controls.forEach(el => {
      el.controls.value.setValue(false);
    });
    choice.controls.value.setValue(true);
    e.source.checked = true;
  }

  saveLastSelect(lastSelect, select: string) {
    lastSelect.setValue(select);
  }

  changeControl(question, i) {
    const FieldData = question.controls.FieldData;
    const select = question.value.select;
    const lastSelect = question.value.lastSelect;
    if (lastSelect !== select) {
      switch (lastSelect) {
        case 'single-choice':
        case 'multiple-choice':
        case 'dropdown-menu':
          switch (select) {
            case 'single-choice':
            case 'multiple-choice':
            case 'dropdown-menu':
              break;
            default:
              this.fieldRemoving(FieldData, select);
              break;
          }
          break;
        case 'single-grid':
        case 'multiple-grid':
          switch (select) {
            case 'single-grid':
            case 'multiple-grid':
              break;
            default:
              this.fieldRemoving(FieldData, select);
              break;
          }
          break;
        default:
          this.fieldRemoving(FieldData, select);
          break;
      }
    }
  }

  see(f) {
    console.log(f);
  }
  fieldRemoving(FieldData, select) {
    const length = FieldData.controls.length - 1;
    for (let i = length; i >= 0; i--) {
      FieldData.removeAt(i);
    }
    this.addGroup(FieldData, select);
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
