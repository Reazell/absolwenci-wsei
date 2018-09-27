import {
  Component,
  ElementRef,
  OnDestroy,
  OnInit,
  QueryList,
  ViewChildren
} from '@angular/core';
import {
  AbstractControl,
  FormArray,
  FormBuilder,
  FormGroup
} from '@angular/forms';
import { MatDialog } from '@angular/material';
import { ActivatedRoute, Router } from '@angular/router';
// tslint:disable-next-line:no-submodule-imports no-implicit-dependencies
import * as cloneDeep from 'lodash/cloneDeep';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/filter';
import { debounceTime, switchMap } from 'rxjs/operators';
import { Subscription } from 'rxjs/Subscription';
import { Observable, Subject } from '../../../../../../node_modules/rxjs';
import { SharedService } from '../../../../services/shared.service';
import {
  ChoiceOptions,
  ChoiceOptionsData,
  LinearData,
  MainForm,
  MoveDialogData,
  QuestionData,
  RowData,
  Select,
  Tooltip,
  Update,
  Value
} from '../models/survey-creator.models';
import {
  Choice,
  FieldData,
  Question,
  Row,
  Survey
} from '../models/survey.model';
import { SurveyService } from '../services/survey.services';
import { MoveQuestionDialogComponent } from './move-question-dialog/move-question-dialog.component';
import { SendSurveyDialogComponent } from './send-survey-dialog/send-survey-dialog.component';

@Component({
  selector: 'app-survey-creator',
  templateUrl: './survey-creator.component.html',
  styleUrls: ['./survey-creator.component.scss']
})
export class SurveyCreatorComponent implements OnInit, OnDestroy {
  @ViewChildren('inputs')
  inputs: QueryList<ElementRef>;
  @ViewChildren('inputs2')
  inputs2: QueryList<ElementRef>;

  invoiceForm: FormGroup;
  default = 'single-grid';
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

  //
  private updateToApi = new Subject();
  public updateToApi$: Observable<any> = this.updateToApi.asObservable();
  //
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

  constructor(
    private fb: FormBuilder,
    private surveyService: SurveyService,
    private sharedService: SharedService,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    public dialog: MatDialog
  ) {}

  ngOnInit(): void {
    // this.getSurveyId();
    this.subToObs();
    this.getSurvey();
    this.saveSurveyOnClick();
    this.showSurveyOnClick();
    this.showSurveyDialog();
    this.showBackButton();
    this.sharedService.showCreatorButton(true);
  }

  updateSurveySubject(x?) {
    this.updateToApi.next(x);
  }
  subToObs() {
    this.updateToApi$
      .pipe(
        debounceTime(300),
        switchMap(() => this.updateSurveyObs())
      )
      .subscribe(() => {});
  }

  updateSurveyObs() {
    const object: Update = {
      Title: this.invoiceForm.getRawValue().title,
      Questions: this.invoiceForm.getRawValue().questions,
      id: this.id
    };
    return this.surveyService.updateSurvey(object);
  }
  updateSurvey() {
    this.updateSurveyObs().subscribe(
      data => {
        // console.log(data);
      },
      error => {
        console.log(error);
      }
    );
  }
  getSurvey(): void {
    this.activatedRoute.data.map(data => data.cres).subscribe(
      (res: Survey) => {
        if (res) {
          this.id = res.id;
          if (res.questions.length === 0) {
            this.createQuestionData();
            this.updateSurveySubject();
          } else if (res.questions.length > 0) {
            this.createQuestionData(res);
          }
        }
      },
      error => {
        console.log(error);
      }
    );
  }

  showBackButton(): void {
    this.sharedService.showBackButton(true);
  }
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
      data => {
        if (data === true) {
          this.openSurveyDialog();
        }
      }
    );
  }
  openSurveyDialog(): void {
    this.dialog.open(SendSurveyDialogComponent, {
      data: { id: this.id, content: this.invoiceForm.getRawValue() }
    });
  }
  openMoveQuestionDialog(): void {
    const array: QuestionData[] = this.invoiceForm.getRawValue().questions;
    const dialogArr: MoveDialogData[] = [];
    array.forEach(el => {
      const obj: MoveDialogData = {
        content: el.content,
        position: el.QuestionPosition
      };
      dialogArr.push(obj);
    });
    const dialogRef = this.dialog.open(MoveQuestionDialogComponent, {
      data: { content: dialogArr }
    });
    dialogRef.afterClosed().subscribe(res => {
      if (res) {
        this.setQPositionsOnMove(res);
        this.updateSurveySubject();
      }
    });
  }
  openMoveControlDialog(question): void {
    const array: ChoiceOptions[] = question.getRawValue().FieldData[0]
      .choiceOptions;
    /* KEYS: ["viewValue", "optionPosition", "value"] */
    const sth = Object.keys(array[0]);
    const nameArr = {
      content: sth[0],
      position: sth[1]
    };
    this.openMoveDialog(array, nameArr).subscribe(res => {
      if (res) {
        question.controls.FieldData.controls[0].controls.choiceOptions = this.setPositionOnMove(
          question.controls.FieldData.controls[0].controls.choiceOptions,
          res,
          sth[1]
        );
        this.updateSurveySubject();
      }
    });
  }

  // universal
  openMoveDialog(array, nameArr): Observable<any> {
    const dialogArr: MoveDialogData[] = [];
    array.forEach(el => {
      const obj: MoveDialogData = {
        content: el[nameArr.content],
        position: el[nameArr.position]
      };
      dialogArr.push(obj);
    });
    const dialogRef = this.dialog.open(MoveQuestionDialogComponent, {
      data: { content: dialogArr }
    });
    return dialogRef.afterClosed();
  }

  setPositionOnMove(array, res, controlName): FormArray {
    const clonedArr: FormArray = cloneDeep(array);
    const length: number = array.length;
    const moveList: AbstractControl[] = array.controls;
    const clonedMoveList: AbstractControl[] = clonedArr.controls;
    for (let i = 0; i < length; i++) {
      const id = res[i].position;
      clonedArr.setControl(i, moveList[id]);
      // change optionPosition to universal
      clonedMoveList[i]['controls'][controlName].setValue(i);
    }
    return clonedArr;
  }

  // universal

  setControlPositionsOnMove(res, question): void {
    const controlArr: FormArray =
      question.controls.FieldData.controls[0].controls.choiceOptions;
    const clonedArr: FormArray = cloneDeep(controlArr);
    const length: number = controlArr.length;
    const controlsList: AbstractControl[] = controlArr.controls;
    const clonedControlsList: AbstractControl[] = clonedArr.controls;
    for (let i = 0; i < length; i++) {
      const id = res[i].position;
      clonedArr.setControl(i, controlsList[id]);
      clonedControlsList[i]['controls'].optionPosition.setValue(i);
    }
    question.controls.FieldData.controls[0].controls.choiceOptions = clonedArr;
  }
  setQPositionsOnMove(res) {
    const questionArr: FormArray = this.invoiceForm.controls
      .questions as FormArray;
    const clonedArr: FormArray = cloneDeep(questionArr);
    const length: number = questionArr.length;
    const questionsList: AbstractControl[] = questionArr.controls;
    const clonedQuestionList: AbstractControl[] = clonedArr.controls;
    for (let i = 0; i < length; i++) {
      const id = res[i].position;
      clonedArr.setControl(i, questionsList[id]);
      clonedQuestionList[i]['controls'].QuestionPosition.setValue(i);
    }
    this.invoiceForm.controls.questions = clonedArr;
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
        description: '',
        questions: this.fb.array([])
      };
    } else {
      group = {
        title: 'Formularz bez nazwy',
        description: '',
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
    const group: FormGroup = this.addquestionsControls(i, question);
    if (question) {
      const questionArr: FormArray = this.invoiceForm.controls
        .questions as FormArray;
      questionArr.push(group);
    } else {
      this.setNewQuestionPositions(i, group);
      this.updateSurveySubject();
    }
  }
  copyQuestion(question: FormGroup, index: number) {
    const clonedObject: FormGroup = cloneDeep(question);
    this.setNewQuestionPositions(index, clonedObject);
    this.updateSurveySubject();
  }
  setNewQuestionPositions(index: number, object?: FormGroup) {
    const questionArr: FormArray = this.invoiceForm.controls
      .questions as FormArray;
    const length: number = questionArr.length;
    const newIndex: number = index + 1;
    if (index !== length - 1) {
      const questionList: AbstractControl[] = questionArr.controls;
      for (let i: number = newIndex; i < length; i++) {
        questionList[i]['controls'].QuestionPosition.setValue(i + 1);
      }
    }
    if (object) {
      object.controls.QuestionPosition.setValue(newIndex);
      questionArr.insert(newIndex, object);
    }
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
      const group = this.addquestionsControls(-1);
      questionArr.push(group);
    }
    this.updateSurveySubject();
  }
  setCurrentQuestionPositions(
    index: number,
    array: AbstractControl[],
    length: number
  ): void {
    for (let i: number = index; i < length; i++) {
      array[i]['controls'].QuestionPosition.setValue(i);
    }
  }

  addquestionsControls(i: number, question?: Question): FormGroup {
    const group: FormGroup = this.fb.group(
      this.populatequestionsControls(i, question)
    );
    this.createFieldData(group.controls, question);
    return group;
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
        const choiceData: Choice[] = (data as FieldData).choiceOptions;
        choiceData.forEach(choice => {
          this.addChoiceField(choiceOptionsField, name, choice);
        });
      } else {
        (data as ChoiceOptions[]).forEach(choice => {
          this.addChoiceField(choiceOptionsField, name, choice);
        });
      }
    } else {
      this.addChoiceField(choiceOptionsField, name);
      this.updateSurveySubject();
    }
  }
  isFieldData(data: FieldData | ChoiceOptions[]): data is FieldData {
    return (data as FieldData).choiceOptions !== undefined;
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
        const options: Choice[] = (data as FieldData).choiceOptions;
        const rowArr: Row[] = (data as FieldData).rows;
        options.forEach(column => {
          this.addChoiceField(choiceData, 'kolumna', column);
        });
        rowArr.forEach(row => {
          this.addRowControl(choiceData2, 'wiersz', row);
        });
      } else {
        (data as ChoiceOptions[]).forEach(column => {
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
    let group: LinearData;
    if (data) {
      group = {
        minValue: (data as FieldData).minValue,
        maxValue: (data as FieldData).maxValue,
        minLabel: (data as FieldData).minLabel,
        maxLabel: (data as FieldData).maxLabel
      };
    } else {
      group = {
        minValue: 1,
        maxValue: 5,
        minLabel: '',
        maxLabel: ''
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
      this.updateSurveySubject();
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
    const length: number = selectArr.controls.length;
    const group: FormGroup = this.fb.group(
      this.populateChoiceField(name, length, data)
    );
    selectArr.push(group);
    if (!data) {
      this.autofocusField(this.inputs);
    }
  }
  populateChoiceField(
    name: string,
    length: number,
    data?: ChoiceOptions | Choice
  ): ChoiceOptionsData {
    let group: ChoiceOptionsData;
    if (data) {
      group = {
        /* DO NOT CHANGE PROPERTIES ORDER */
        viewValue: data.viewValue,
        optionPosition: (data as Choice).optionPosition,
        value: { value: false, disabled: this.disabled }
      };
    } else {
      group = {
        /* DO NOT CHANGE PROPERTIES ORDER */
        viewValue: `${name} ${length + 1}`,
        optionPosition: length,
        value: { value: false, disabled: this.disabled }
      };
    }
    return group;
  }
  autofocusField(inputs: QueryList<ElementRef>, i?: number): void {
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

  removeField(index: number, formArr: FormArray, row?: boolean): void {
    const length: number = formArr.controls.length - 1;
    formArr.removeAt(index);
    if (index !== length) {
      this.setCurrentFieldPositions(
        index,
        formArr.controls as FormGroup[],
        length,
        row
      );
    }
    this.updateSurveySubject();
  }
  setCurrentFieldPositions(
    index: number,
    arr: FormGroup[],
    length: number,
    row?: boolean
  ): void {
    {
      if (!row) {
        for (let i: number = index; i < length; i++) {
          arr[i].controls.optionPosition.setValue(i);
        }
      } else {
        for (let i: number = index; i < length; i++) {
          arr[i].controls.rowPosition.setValue(i);
        }
      }
    }
  }
  saveLastSelect(lastSelect: AbstractControl, select: string): void {
    lastSelect.setValue(select);
  }

  changeControl(question: FormGroup): void {
    const fieldData: FormArray = question.controls.FieldData as FormArray;
    const select: string = question.value.select;
    const lastSelect: string = question.value.lastSelect;
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
              const control: ChoiceOptions[] = fieldData.controls[0][
                'controls'
              ].choiceOptions.getRawValue();
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
              const control: ChoiceOptions[] = fieldData.controls[0][
                'controls'
              ].choiceOptions.getRawValue();
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
      this.updateSurveySubject();
    }
  }
  fieldRemoving(
    fieldData: FormArray,
    select: string,
    data?: ChoiceOptions[]
  ): void {
    const length: number = fieldData.controls.length - 1;
    for (let i = length; i >= 0; i--) {
      fieldData.removeAt(i);
    }
    this.addGroup(fieldData, select, data);
  }
  onSubmit(): void {
    // console.log(JSON.stringify(this.invoiceForm.getRawValue()));
    // if (this.id) {
    //   this.updateSurvey();
    // } else {
    //   this.createSurvey();
    // }
  }

  createSurvey(): void {
    this.createSurveySub = this.surveyService
      .createSurvey(this.invoiceForm.getRawValue())
      .subscribe(
        data => {
          this.router.navigate(['/app/admin/survey-dashboard']);
        },
        error => {
          console.log(error);
        }
      );
  }

  showSurvey(): void {
    const string: string =
      'http://localhost:4200/app/admin/survey/viewform/' + this.id;
    window.open(string, '_blank');
  }

  ngOnDestroy(): void {
    this.saveSurveySub.unsubscribe();
    this.showSurveySub.unsubscribe();
    this.showSurveyDialogSub.unsubscribe();
    this.sharedService.showCreatorButton(false);
    this.sharedService.showBackButton(false);
  }
}
