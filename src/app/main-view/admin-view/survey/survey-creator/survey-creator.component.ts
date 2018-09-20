import {
  Survey,
  Question,
  FieldData,
  Choice,
  Row
} from './../../classes/survey.model';
import {
  Select,
  Value,
  Tooltip,
  ChoiceOptions,
  QuestionData,
  Update,
  MainForm,
  RowData
} from '../../classes/survey-creator.models';
import { SendSurveyDialogComponent } from './send-survey-dialog/send-survey-dialog.component';
import { Router, ActivatedRoute } from '@angular/router';
import {
  Component,
  OnInit,
  ViewChildren,
  QueryList,
  OnDestroy,
  AfterViewInit
} from '@angular/core';
import {
  FormGroup,
  FormBuilder,
  FormArray,
  AbstractControl
} from '@angular/forms';
import * as cloneDeep from 'lodash/cloneDeep';
import { MatDialog } from '@angular/material';
import { SurveyService } from '../../../services/survey.services';
import { SharedService } from '../../../../services/shared.service';
import { Subscription } from '../../../../../../node_modules/rxjs';

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
  default = 'single-grid';
  loaded = false;
  disabled = true;
  index = 0;
  questionIndex = 0;
  id: number;
  // subs
  saveSurveySub: Subscription;
  showSurveySub: Subscription;
  createSurveySub: Subscription;
  surveyIDSub: Subscription;
  showSurveyDialogSub: Subscription;

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
  info: Tooltip = {
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

  ngOnInit(): void {
    this.getSurveyId();
    this.saveSurveyOnClick();
    this.showSurveyOnClick();
    this.showSurveyDialog();
    this.sharedService.showCreatorButton(true);
  }

  ngAfterViewInit() {}

  saveSurveyOnClick(): void {
    this.saveSurveySub = this.sharedService.saveButton.subscribe(() => {
      this.onSubmit();
    });
  }
  showSurveyOnClick(): void {
    this.showSurveySub = this.sharedService.showButton.subscribe(() => {
      this.showSurvey();
    });
  }
  showSurveyDialog(): void {
    this.showSurveyDialogSub = this.sharedService.showSurveyDialog.subscribe(
      () => {
        this.openSurveyDialog();
      }
    );
  }
  openSurveyDialog(): void {
    this.dialog.open(SendSurveyDialogComponent, {
      data: { id: this.id, content: this.invoiceForm.getRawValue() }
    });
  }
  getSurveyId(): void {
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
  getSurvey(): void {
    this.surveyService.getSurveyWithId(this.id).subscribe(
      data => {
        this.createQuestionData(data);
        this.loaded = true;
        // console.log(data);
      },
      error => {
        console.log(error);
      }
    );
  }
  // creating FormGroup  -- Main Form
  createQuestionData(form?: Survey): void {
    this.invoiceForm = this.fb.group(this.populateQuestionData(form));
    this.createQuestionField(form);
  }
  populateQuestionData(form?: Survey): MainForm {
    let group: MainForm;
    if (form) {
      group = {
        title: form.title,
        questions: this.fb.array([])
      };
    } else {
      group = {
        title: 'Formularz bez nazwy',
        questions: this.fb.array([])
      };
    }
    return group;
  }
  createQuestionField(form?: Survey): void {
    if (form) {
      const questions: Question[] = form.questions;
      const i = -1;
      questions.forEach(question => {
        this.addQuestion(i, question);
      });
    } else {
      this.addQuestion(-1);
    }
  }

  addQuestion(i: number, question?: Question): void {
    const questions: FormArray = this.invoiceForm.get(`questions`) as FormArray;
    this.addquestionsControls(questions, i, question);
  }
  copyQuestion(question: FormGroup, index: number) {
    const sortableList: FormArray = this.invoiceForm.controls
      .questions as FormArray;
    const length: number = sortableList.length;
    const clonedObject: FormGroup = cloneDeep(question);
    const newIndex: number = index + 1;
    if (index !== length - 1) {
      const questionList: Array<AbstractControl> = sortableList.controls;
      for (let i: number = newIndex; i < length; i++) {
        questionList[newIndex]['controls'].QuestionPosition.setValue(i + 1);
      }
    }
    clonedObject.controls.QuestionPosition.setValue(newIndex);
    sortableList.insert(newIndex, clonedObject);
  }
  removeQuestion(i: number): void {
    const questionArr: FormArray = this.invoiceForm.controls
      .questions as FormArray;
    const length: number = questionArr.controls.length;
    if (length > 1) {
      questionArr.removeAt(i);
      if (i !== length - 1) {
        this.setCurrentQuestionPositions(i, questionArr.controls, length - 1);
      }
    } else {
      questionArr.removeAt(0);
      this.addquestionsControls(questionArr, -1);
    }
  }
  setCurrentQuestionPositions(
    index: number,
    array: Array<AbstractControl>,
    length: number
  ): void {
    for (let i: number = index; i < length; i++) {
      array[i]['controls'].QuestionPosition.setValue(i);
    }
  }

  addquestionsControls(
    questions: FormArray,
    i: number,
    question?: Question
  ): void {
    const group: FormGroup = this.fb.group(
      this.populatequestionsControls(i, question)
    );
    this.createFieldData(group.controls, question);
    questions.push(group);
  }
  populatequestionsControls(i: number, question?: Question): QuestionData {
    let group: QuestionData;
    if (question) {
      group = {
        content: question.content,
        select: question.select,
        lastSelect: undefined,
        QuestionPosition: question.questionPosition,
        FieldData: this.fb.array([])
      };
    } else {
      group = {
        content: '',
        select: this.default,
        lastSelect: undefined,
        QuestionPosition: i + 1,
        FieldData: this.fb.array([])
      };
    }
    return group;
  }
  createFieldData(controls: any, question?: Question): void {
    if (question) {
      const fieldData: FieldData[] = question.fieldData;
      // const i = -1;
      fieldData.forEach(data => {
        this.addGroup(controls.FieldData, controls.select.value, data);
      });
    } else {
      this.addGroup(controls.FieldData, controls.select.value);
    }
  }
  addGroup(
    fieldData: FormArray,
    select: string,
    data?: FieldData | ChoiceOptions[]
  ): void {
    switch (select) {
      case 'short-answer':
      case 'long-answer':
        this.addInput(fieldData);
        break;
      case 'linear-scale':
        this.addLinearScaleField(fieldData, data);
        break;
      case 'dropdown-menu':
      case 'single-choice':
      case 'multiple-choice':
        this.addArray(fieldData, data);
        break;
      case 'single-grid':
      case 'multiple-grid':
        this.addSelectionGridField(fieldData, data);
        break;
    }
  }
  addArray(fieldData: FormArray, data?: FieldData | ChoiceOptions[]): void {
    const group: FormGroup = this.fb.group({
      choiceOptions: this.fb.array([])
    });
    this.createChoiceControls(
      group.controls.choiceOptions as FormArray,
      'opcja',
      data
    );
    fieldData.push(group);
  }
  createChoiceControls(
    choiceOptionsField: FormArray,
    name: string,
    data?: FieldData | ChoiceOptions[]
  ): void {
    if (data) {
      const bool: boolean = this.isFieldData(data);
      if (bool) {
        const choiceData: Choice[] = (<FieldData>data).choiceOptions;
        choiceData.forEach(choice => {
          this.addChoiceField(choiceOptionsField, name, choice);
        });
      } else {
        (<ChoiceOptions[]>data).forEach(choice => {
          this.addChoiceField(choiceOptionsField, name, choice);
        });
      }
    } else {
      this.addChoiceField(choiceOptionsField, name);
    }
  }
  isFieldData(data: FieldData | ChoiceOptions[]): data is FieldData {
    return <FieldData>data !== undefined;
  }
  addInput(fieldData: FormArray): void {
    const group: FormGroup = this.fb.group({
      input: [{ value: '', disabled: this.disabled }]
    });
    fieldData.push(group);
  }
  addSelectionGridField(
    fieldData: FormArray,
    data?: FieldData | ChoiceOptions[]
  ): void {
    const group: FormGroup = this.fb.group({
      choiceOptions: this.fb.array([]),
      rows: this.fb.array([])
    });
    this.addField(
      group.controls.choiceOptions as FormArray,
      group.controls.rows as FormArray,
      data
    );
    fieldData.push(group);
  }

  addField(
    choiceData: FormArray,
    choiceData2: FormArray,
    data?: FieldData | ChoiceOptions[]
  ): void {
    if (data) {
      const bool: boolean = this.isFieldData(data);
      if (bool) {
        const options: Choice[] = (<FieldData>data).choiceOptions;
        const rowArr: Row[] = (<FieldData>data).rows;
        options.forEach(column => {
          this.addChoiceField(choiceData, 'kolumna', column);
        });
        rowArr.forEach(row => {
          this.addRowControl(choiceData2, 'wiersz', row);
        });
      } else {
        (<ChoiceOptions[]>data).forEach(column => {
          this.addChoiceField(choiceData, 'kolumna', column);
        });
        this.addRowControl(choiceData2, 'wiersz');
      }
    } else {
      this.addChoiceField(choiceData, 'kolumna');
      this.addRowControl(choiceData2, 'wiersz');
    }
  }

  addLinearScaleField(
    choiceArr: FormArray,
    data?: FieldData | ChoiceOptions[]
  ): void {
    const group = this.fb.group(this.populateLinearScale(data));
    choiceArr.push(group);
  }
  populateLinearScale(data?: FieldData | ChoiceOptions[]) {
    let group;
    if (data) {
      group = {
        minValue: [(<FieldData>data).minValue || 1],
        maxValue: [(<FieldData>data).maxValue || 5],
        minLabel: [(<FieldData>data).minLabel || ''],
        maxLabel: [(<FieldData>data).maxLabel || '']
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
  addRowControl(selectArr: FormArray, name: string, data?: Row): void {
    const length: number = selectArr.controls.length;
    const group: FormGroup = this.fb.group(
      this.populateRowControl(name, length, data)
    );
    selectArr.push(group);
    if (!data) {
      this.autofocusField(this.inputs2, length);
    }
  }
  populateRowControl(name: string, length: number, data?: Row): RowData {
    let group: RowData;
    if (data) {
      group = {
        rowPosition: data.rowPosition,
        input: data.input
      };
    } else {
      group = {
        rowPosition: length,
        input: `${name} ${length + 1}`
      };
    }
    return group;
  }
  addChoiceField(
    selectArr: FormArray,
    name: string,
    data?: ChoiceOptions | Choice
  ): void {
    const length = selectArr.controls.length;
    const group = this.fb.group(this.populateChoiceField(name, length, data));
    selectArr.push(group);
    if (!data) {
      this.autofocusField(this.inputs);
    }
  }
  populateChoiceField(
    name: string,
    length: number,
    data?: ChoiceOptions | Choice
  ) {
    let group;
    if (data) {
      group = {
        value: { value: false, disabled: this.disabled },
        viewValue: data.viewValue,
        ChoicePosition: [(<Choice>data).optionPosition]
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

  removeField(index, fieldData, row?) {
    const length = fieldData.controls.length - 1;
    fieldData.removeAt(index);
    if (index !== length) {
      this.setCurrentFieldPositions(index, fieldData.controls, length, row);
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
    const fieldData = question.controls.FieldData;
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
              const control = fieldData.controls[0].controls.choiceOptions.getRawValue();
              this.fieldRemoving(fieldData, select, control);
              break;
            default:
              this.fieldRemoving(fieldData, select);
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
              const control = fieldData.controls[0].controls.choiceOptions.getRawValue();
              this.fieldRemoving(fieldData, select, control);
              break;
            default:
              this.fieldRemoving(fieldData, select);
              break;
          }
          break;
        default:
          this.fieldRemoving(fieldData, select);
          break;
      }
    }
  }
  fieldRemoving(fieldData, select, data?) {
    const length = fieldData.controls.length - 1;
    for (let i = length; i >= 0; i--) {
      fieldData.removeAt(i);
    }
    this.addGroup(fieldData, select, data);
  }
  onSubmit() {
    // console.log(JSON.stringify(this.invoiceForm.getRawValue()));
    if (this.id) {
      this.updateSurvey();
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
    const object: Update = {
      Title: this.invoiceForm.getRawValue().title,
      Questions: this.invoiceForm.getRawValue().questions,
      id: this.id
    };
    this.createSurveySub = this.surveyService.updateSurvey(object).subscribe(
      data => {
        // console.log(data);
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
    // this.surveyService.openCreator(undefined);
    this.saveSurveySub.unsubscribe();
    this.showSurveySub.unsubscribe();
    this.showSurveyDialogSub.unsubscribe();
    this.sharedService.showCreatorButton(false);
  }

  see(f) {
    console.log(f);
  }
}
