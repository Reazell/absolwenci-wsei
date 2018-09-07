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

@Component({
  selector: 'app-survey-creator',
  templateUrl: './survey-creator.component.html',
  styleUrls: ['./survey-creator.component.scss']
})
export class SurveyCreatorComponent implements OnInit, OnDestroy {
  // @ViewChildren('inputs')
  // inputs: QueryList<any>;
  invoiceForm: FormGroup;
  default = 'dropdown-menu';
  disabled = false;
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

  constructor(
    private fb: FormBuilder,
    private surveyService: SurveyService,
    private router: Router
  ) {}

  ngOnInit() {
    this.invoiceForm = this.fb.group({
      Form_Title: ['Formularz bez nazwy'],
      QuestionData: this.fb.array([this.addRows()])
    });

    // this.router.events.subscribe(val => {
    //   if (val instanceof NavigationEnd) {
    //     console.log('NavigationEnd!');
    //   }
    // });
  }
  ngOnDestroy() {}

  onSubmit() {
    this.surveyService.saveSurvey(this.invoiceForm);
    this.router.navigateByUrl(`/app/admin/viewform`);
    // window.open('http://localhost:4200/app/admin/viewform', '_blank');
  }

  addRows() {
    const group = this.fb.group({
      question: [''],
      select: [this.default],
      lastSelect: [undefined],
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
    if (questionArr.controls.length > 1) {
      questionArr.removeAt(index);
    } else {
      questionArr.removeAt(0);
      questionArr.push(this.addRows());
    }
  }

  addGroup(FieldData, select: string) {
    switch (select) {
      case 'short-answer':
      case 'long-answer':
        this.addInput(FieldData);
        break;
      case 'dropdown-menu':
        this.addArray(FieldData);
        break;
      case 'linear-scale':
        this.addLinearScaleField(FieldData);
        break;
      case 'single-choice':
      case 'multiple-choice':
        this.addCheckField(FieldData, 'opcja');
        break;
      case 'single-grid':
      case 'multiple-grid':
        this.addSelectionGridField(FieldData);
        break;
    }
  }
  addArray(FieldData) {
    const group = this.fb.group({
      input: this.fb.array([])
    });
    FieldData.push(group);
    this.addCheckField(group.controls.input, 'opcja');
  }
  addInput(FieldData) {
    const group = this.fb.group({
      input: [{ value: '', disabled: this.disabled }]
    });
    FieldData.push(group);
    // this.autofocusField();
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
  see(sth) {
    console.log(sth);
  }
  addInputOption(selectArr, name) {
    const length = selectArr.controls.length;
    const group = this.fb.group({
      input: `${name} ${length}`
    });
    selectArr.push(group);
    // this.autofocusField(length);
  }
  addCheckField(selectArr, name) {
    // console.log(selectArr);
    const length = selectArr.controls.length;
    const group = this.fb.group({
      value: [{ value: false, disabled: this.disabled }],
      viewValue: `${name} ${length}`
    });
    selectArr.push(group);
    // this.autofocusField();
  }
  // autofocusField(i?) {
  //   setTimeout(() => {
  //     if (this.inputs && this.inputs.last) {
  //       if (!i) {
  //         this.inputs.last.nativeElement.focus();
  //       } else {
  //         this.inputs.toArray()[i].nativeElement.focus();
  //       }
  //     }
  //   }, 0);
  // }
  removeField(index, FieldData) {
    FieldData.removeAt(index);
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
          switch (select) {
            case 'single-choice':
            case 'multiple-choice':
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
