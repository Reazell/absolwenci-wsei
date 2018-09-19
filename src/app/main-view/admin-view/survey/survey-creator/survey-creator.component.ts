import { SendSurveyDialogComponent } from './send-survey-dialog/send-survey-dialog.component';
import { Router, NavigationEnd, ActivatedRoute } from '@angular/router';
import {
  Component,
  OnInit,
  ViewChildren,
  QueryList,
  OnDestroy,
  AfterViewInit
} from '@angular/core';
import { FormGroup, FormBuilder, FormArray } from '@angular/forms';
import * as cloneDeep from 'lodash/cloneDeep';
import { MatDialog } from '@angular/material';
import { Select, Value } from '../../classes/survey-creator.models';
import { SurveyService } from '../../../services/survey.services';
import { SharedService } from '../../../../services/shared.service';

@Component({
  selector: 'app-survey-creator',
  templateUrl: './survey-creator.component.html',
  styleUrls: ['./survey-creator.component.scss']
})
export class SurveyCreatorComponent
  implements OnInit, OnDestroy, AfterViewInit {
  @ViewChildren('inputs')
  inputs: QueryList<any>;
  @ViewChildren('inputs2')
  inputs2: QueryList<any>;

  invoiceForm: FormGroup;
  default = 'single-choice';
  loaded = false;
  disabled = true;
  index = 0;
  questionIndex = 0;
  id: number;
  // subs
  saveSurveySub: any;
  showSurveySub: any;
  createSurveySub: any;
  surveyIDSub: any;
  showSurveyDialogSub: any;

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

  sort(sortableList, event) {
      // if (this.index === 0) {
      //   // console.log(sortableList);
      //   // console.log(event);
      //   const current = sortableList[event.currentIndex];
      //   const swapWith = sortableList[event.newIndex];
      //   sortableList[event.newIndex] = current;
      //   sortableList[event.currentIndex] = swapWith;
      //   this.index++;
      // } else {
      //   this.index = 0;
      // }
  }

  constructor(
    private fb: FormBuilder,
    private surveyService: SurveyService,
    private sharedService: SharedService,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    public dialog: MatDialog
  ) {}

  ngOnInit() {
    this.getSurveyId();
    this.saveSurveyOnClick();
    this.showSurveyOnClick();
    this.showSurveyDialog();
    this.sharedService.showCreatorButton(true);
  }

  ngAfterViewInit() {}

  saveSurveyOnClick() {
    this.saveSurveySub = this.sharedService.saveButton.subscribe(() => {
      this.onSubmit();
    });
  }
  showSurveyOnClick() {
    this.showSurveySub = this.sharedService.showButton.subscribe(() => {
      this.showSurvey();
    });
  }
  showSurveyDialog() {
    this.showSurveyDialogSub = this.sharedService.showSurveyDialog.subscribe(
      () => {
        this.openSurveyDialog();
      }
    );
  }
  openSurveyDialog() {
    this.dialog.open(SendSurveyDialogComponent, {
      data: { id: this.id, content: this.invoiceForm.getRawValue() }
    });
  }
  getSurveyId() {
    this.surveyIDSub = this.activatedRoute.params.subscribe(params => {
      this.id = Number(params['id']);
      if (this.id) {
        this.getSurvey();
      } else {
        this.loaded = true;
        this.createQuestionData();
      }
    });
  }
  getSurvey() {
    this.surveyService.getSurveyWithId(this.id).subscribe(
      data => {
        this.createQuestionData(data);
        this.loaded = true;
        console.log(data);
      },
      error => {
        console.log(error);
      }
    );
  }
  // creating FormGroup  -- Main Form
  createQuestionData(form?) {
    this.invoiceForm = this.fb.group(this.populateQuestionData(form));
    this.createQuestionField(form);
  }
  populateQuestionData(form?) {
    let group;
    if (form) {
      group = {
        title: [form.title],
        questions: this.fb.array([])
      };
    } else {
      group = {
        title: ['Formularz bez nazwy'],
        questions: this.fb.array([])
      };
    }
    return group;
  }
  createQuestionField(form?) {
    if (form) {
      const questions = form.questions;
      const i = -1;
      questions.forEach(question => {
        this.addQuestion(i, question);
      });
    } else {
      this.addQuestion(-1);
    }
  }

  addQuestion(i, question?) {
    const questions: FormArray = this.invoiceForm.get(`questions`) as FormArray;
    this.addquestionsControls(questions, i, question);
  }
  copyQuestion(question, index) {
    const sortableList = this.invoiceForm.controls.questions as FormArray;
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
    const questionArr = this.invoiceForm.controls.questions as FormArray;
    const length = questionArr.controls.length;
    if (questionArr.controls.length > 1) {
      questionArr.removeAt(i);
      if (i !== length - 1) {
        this.setCurrentQuestionPositions(i, questionArr.controls, length - 1);
      }
    } else {
      questionArr.removeAt(0);
      this.addquestionsControls(questionArr, -1);
    }
  }
  setCurrentQuestionPositions(index, array, length) {
    for (let i = index; i < length; i++) {
      array[i].controls.QuestionPosition.setValue(i);
    }
  }

  addquestionsControls(questions, i, question?) {
    const group = this.fb.group(this.populatequestionsControls(i, question));
    this.createFieldData(group.controls, question);
    questions.push(group);
  }
  populatequestionsControls(i, question?) {
    let group;
    if (question) {
      group = {
        content: [question.content],
        select: [question.select],
        lastSelect: [undefined],
        QuestionPosition: [question.questionPosition],
        FieldData: this.fb.array([])
      };
    } else {
      group = {
        content: [''],
        select: [this.default],
        lastSelect: [undefined],
        QuestionPosition: [i + 1],
        FieldData: this.fb.array([])
      };
    }
    return group;
  }
  createFieldData(controls, question?) {
    if (question) {
      const FieldData = question.fieldData;
      // const i = -1;
      FieldData.forEach(data => {
        this.addGroup(controls.FieldData, controls.select.value, data, true);
      });
    } else {
      this.addGroup(controls.FieldData, controls.select.value);
    }
  }
  addGroup(FieldData, select: string, data?, isForm?) {
    switch (select) {
      case 'short-answer':
      case 'long-answer':
        this.addInput(FieldData);
        break;
      case 'linear-scale':
        this.addLinearScaleField(FieldData, data);
        break;
      case 'dropdown-menu':
      case 'single-choice':
      case 'multiple-choice':
        this.addArray(FieldData, data, isForm);
        break;
      case 'single-grid':
      case 'multiple-grid':
        this.addSelectionGridField(FieldData, data, isForm);
        break;
    }
  }
  addArray(FieldData, data?, isForm?) {
    const group = this.fb.group({
      choiceOptions: this.fb.array([])
    });
    this.createChoiceControls(
      group.controls.choiceOptions,
      'opcja',
      data,
      isForm
    );
    FieldData.push(group);
  }
  createChoiceControls(choiceOptionsField, name, data?, isForm?) {
    if (data) {
      if (isForm === true) {
        const choiceData = data.choiceOptions;
        choiceData.forEach(choice => {
          this.addChoiceField(choiceOptionsField, name, choice);
        });
      } else {
        data.forEach(choice => {
          this.addChoiceField(choiceOptionsField, name, choice);
        });
      }
    } else {
      this.addChoiceField(choiceOptionsField, name);
    }
  }
  addInput(FieldData) {
    const group = this.fb.group({
      input: [{ value: '', disabled: this.disabled }]
    });
    FieldData.push(group);
  }
  addSelectionGridField(FieldData, data?, isForm?) {
    const group = this.fb.group({
      choiceOptions: this.fb.array([]),
      rows: this.fb.array([])
    });
    this.addField(
      group.controls.choiceOptions,
      group.controls.rows,
      isForm,
      data
    );
    FieldData.push(group);
  }

  addField(choiceData, choiceData2, isForm?, data?) {
    if (isForm !== undefined && data !== undefined) {
      if (isForm === true) {
        data.choiceOptions.forEach(column => {
          this.addChoiceField(choiceData, 'kolumna', column);
        });
        data.rows.forEach(row => {
          this.addRowControl(choiceData2, 'wiersz', row);
        });
      } else if (isForm === false) {
        data.forEach(column => {
          this.addChoiceField(choiceData, 'kolumna', column);
        });
        this.addRowControl(choiceData2, 'wiersz');
      }
    } else {
      this.addChoiceField(choiceData, 'kolumna');
      this.addRowControl(choiceData2, 'wiersz');
    }
  }

  addLinearScaleField(choiceArr, data?) {
    const group = this.fb.group(this.populateLinearScale(data));
    choiceArr.push(group);
  }
  populateLinearScale(data?) {
    let group;
    if (data) {
      group = {
        minValue: [data.minValue || 1],
        maxValue: [data.maxValue || 5],
        minLabel: [data.minLabel || ''],
        maxLabel: [data.maxLabel || '']
      };
    } else {
      group = {
        minValue: [1],
        maxValue: [5],
        minLabel: [''],
        maxLabel: ['']
      };
    }
    return group;
  }
  addRowControl(selectArr, name, data?) {
    const length = selectArr.controls.length;
    const group = this.fb.group(this.populateRowControl(name, length, data));
    selectArr.push(group);
    if (!data) {
      this.autofocusField(this.inputs2, length);
    }
  }
  populateRowControl(name, length, data?) {
    let group;
    if (data) {
      group = {
        rowPosition: [data.rowPosition],
        input: [data.input]
      };
    } else {
      group = {
        rowPosition: [length],
        input: [`${name} ${length + 1}`]
      };
    }
    return group;
  }
  addChoiceField(selectArr, name, data?) {
    const length = selectArr.controls.length;
    const group = this.fb.group(this.populateChoiceField(name, length, data));
    selectArr.push(group);
    if (!data) {
      this.autofocusField(this.inputs);
    }
  }
  populateChoiceField(name, length, data?) {
    let group;
    if (data) {
      group = {
        value: [{ value: false, disabled: this.disabled }],
        viewValue: [data.viewValue],
        ChoicePosition: [data.optionPosition]
      };
    } else {
      group = {
        value: [{ value: false, disabled: this.disabled }],
        viewValue: [`${name} ${length + 1}`],
        ChoicePosition: [length]
      };
    }
    return group;
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
          arr[i].controls.rowPosition.setValue(i);
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
            case 'single-grid':
            case 'multiple-grid':
              const control = FieldData.controls[0].controls.choiceOptions.getRawValue();
              this.fieldRemoving(FieldData, select, control, false);
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
            case 'single-choice':
            case 'multiple-choice':
            case 'dropdown-menu':
              const control = FieldData.controls[0].controls.choiceOptions.getRawValue();
              this.fieldRemoving(FieldData, select, control);
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
  fieldRemoving(FieldData, select, data?, isForm?) {
    const length = FieldData.controls.length - 1;
    for (let i = length; i >= 0; i--) {
      FieldData.removeAt(i);
    }
    this.addGroup(FieldData, select, data, isForm);
  }
  onSubmit() {
    // console.log(JSON.stringify(this.invoiceForm.getRawValue()));
    if (this.id) {
      // this.updateSurvey();
    } else {
      this.createSurvey();
    }
  }

  createSurvey() {
    this.createSurveySub = this.surveyService
      .createSurvey(this.invoiceForm.getRawValue())
      .subscribe(
        data => {
          console.log(data);
          this.router.navigate(['/app/admin/']);
        },
        error => {
          console.log(error);
        }
      );
  }
  updateSurvey() {
    const object = {
      Title: this.invoiceForm.getRawValue().title,
      Questions: this.invoiceForm.getRawValue().questions,
      surveyId: this.id
    };
    console.log(JSON.stringify(object));
    this.createSurveySub = this.surveyService
      .updateSurvey(this.invoiceForm.getRawValue(), this.id)
      .subscribe(
        data => {
          console.log(data);
          this.router.navigate(['/app/admin/']);
        },
        error => {
          console.log(error);
        }
      );
  }
  showSurvey() {
    const string = 'http://localhost:4200/app/admin/viewform/' + this.id;
    window.open(string, '_blank');
  }

  ngOnDestroy() {
    this.surveyService.openCreator(undefined);
    this.saveSurveySub.unsubscribe();
    this.showSurveySub.unsubscribe();
    this.showSurveyDialogSub.unsubscribe();
    this.sharedService.showCreatorButton(false);
  }

  see(f) {
    console.log(f);
  }
}
