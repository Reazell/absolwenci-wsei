import { Component, OnDestroy, OnInit } from '@angular/core';
import {
  FormArray,
  FormBuilder,
  FormControl,
  FormGroup,
  Validators
} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs/Subscription';
import { QuestionData } from '../main-view/admin-view/survey-container/models/survey-creator.models';
import { SurveyService } from '../main-view/admin-view/survey-container/services/survey.services';
import { SharedService } from '../services/shared.service';

@Component({
  selector: 'app-survey-viewform',
  templateUrl: './survey-viewform.component.html',
  styleUrls: ['./survey-viewform.component.scss']
})
export class SurveyViewformComponent implements OnInit, OnDestroy {
  invoiceForm: FormGroup;
  defaultQuestion = 'Brak pytania';
  loader = false;
  showError = false;
  id: number;
  hash: string;
  title: string;
  defaultError = 'Odpowiedź na to pytanie jest wymagana';
  singleGridError = 'To pytanie wymaga jednej odpowiedzi w każdym wierszu';
  multipleGridError =
    'To pytanie wymaga co najmniej jednej odpowiedzi w każdym wierszu';

  // subs
  surveyIDSub: Subscription = new Subscription();
  editSurveySub: Subscription = new Subscription();

  constructor(
    private surveyService: SurveyService,
    private fb: FormBuilder,
    private router: Router,
    private sharedService: SharedService,
    private activatedRoute: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.getSurvey();
    this.showUserInfo();
    this.sharedService.showSendButton(true);
    this.editSurvey();
  }
  showAdminMenu(x): void {
    this.sharedService.showAdminMain(x);
  }
  showUserInfo(): void {
    this.sharedService.showUser(false);
  }
  getSurvey(): void {
    this.activatedRoute.data.map(data => data.cres).subscribe(
      res => {
        if (res) {
          console.log(res);

          this.createQuestionData(res);
          this.title = res['title'];
          this.id = Number(this.activatedRoute.snapshot.params['id']);
          this.hash = this.activatedRoute.snapshot.params['hash'];
          this.loader = true;
          this.surveyService.isCreatorLoading(false);
          if (!this.hash) {
            this.showBackButton(true);
          } else {
            this.showAdminMenu(false);
          }
        }
      },
      error => {
        console.log(error);
        this.surveyService.isCreatorLoading(false);
      }
    );
  }
  showBackButton(x): void {
    this.sharedService.showBackButton(x);
  }
  sendSurvey(): void {
    if (this.invoiceForm.valid) {
      this.showError = false;
      this.surveyService
        .saveSurveyAnswer(this.invoiceForm.getRawValue(), this.id, this.hash)
        .subscribe(
          data => {
            console.log(data);
          },
          error => {
            console.log(error);
          }
        );
    } else {
      this.showError = true;
      console.log(this.invoiceForm);
    }
  }
  editSurvey(): void {
    this.editSurveySub = this.sharedService.editButton.subscribe(() => {
      this.routeToEditSurvey();
    });
  }

  routeToSurveyCompleted() {
    this.router.navigateByUrl('./formResponse');
  }
  routeToEditSurvey(): void {
    this.router.navigateByUrl('/app/admin/create/' + this.id);
  }

  ngOnDestroy(): void {
    this.sharedService.showSendButton(false);
    this.editSurveySub.unsubscribe();
    if (!this.hash) {
      this.showBackButton(false);
    } else {
      this.showAdminMenu(true);
    }
  }

  updateSelection(choiceOptions, radio, e?): void {
    // console.log(choiceOptions);
    choiceOptions.forEach(el => {
      el.controls.value.setValue(false);
    });
    radio.setValue(true);
    if (e) {
      e.source.checked = true;
    }
  }

  sth(f) {
    console.log(f);
  }

  createQuestionData(data) {
    this.invoiceForm = this.fb.group({
      title: [data.title],
      // Created_Date: [data.Created_Date],
      // Created_Time: [data.Created_Time],
      questions: this.fb.array([])
    });
    data.questions.forEach(question => {
      this.createQuestion(question);
    });
  }

  createQuestion(question) {
    const control: FormArray = this.invoiceForm.get(`questions`) as FormArray;
    const group = this.addRows(question);
    control.push(group);
  }

  addRows(question: QuestionData) {
    const group = this.fb.group({
      content: [question.content || this.defaultQuestion],
      select: [question.select],
      QuestionPosition: [question.QuestionPosition],
      FieldData: this.fb.array([]),
      isRequired: question.isRequired
    });
    this.createFieldData(question, group.controls);
    return group;
  }

  createFieldData(question, controls) {
    question.fieldData.forEach(data => {
      this.addGroup(
        controls.FieldData,
        controls.select.value,
        controls.isRequired.value,
        data
      );
    });
  }

  addGroup(FieldData, select: string, isRequired: boolean, data) {
    switch (select) {
      case 'short-answer':
      case 'long-answer':
        this.addInput(FieldData, isRequired);
        break;
      case 'linear-scale':
        this.createRadio(FieldData, data, isRequired);
        break;
      case 'dropdown-menu':
      case 'single-choice':
      case 'multiple-choice':
        // this.addCheckField(FieldData, data);
        this.addArray(FieldData, isRequired, data);
        break;
      case 'single-grid':
      case 'multiple-grid':
        this.createRow(FieldData, data, isRequired);
        break;
    }
  }

  addArray(FieldData, isRequired: boolean, data) {
    const group = this.fb.group({
      choiceOptions: this.fb.array([])
    });
    FieldData.push(group);
    data.choiceOptions.forEach(choiceOptions => {
      // this.addCheckField(group.controls.choiceOptions, choiceOptions);
      this.createViewValue(
        group.controls.choiceOptions,
        choiceOptions.viewValue,
        choiceOptions.optionPosition,
        isRequired
      );
    });
  }
  addInput(FieldData, isRequired) {
    const group = this.fb.group({
      input: ''
    });
    if (isRequired) {
      group.controls.input.setValidators([Validators.required]);
    }
    FieldData.push(group);
  }
  addCheckField(selectArr, data) {
    // console.log();
    const group = this.fb.group({
      // input: false,
      value: false,
      viewValue: [data.viewValue]
    });
    selectArr.push(group);
  }

  // grid
  // rows
  createRow(fieldData, oldFieldData, isRequired) {
    const group = this.fb.group({
      rows: this.fb.array([])
    });
    fieldData.push(group);
    const rowLength = oldFieldData.rows.length;

    for (let i = 0; i < rowLength; i++) {
      this.createGrid(group.controls.rows, oldFieldData, i, isRequired);
    }
  }

  createGrid(rows, oldFieldData, i, isRequired) {
    const group = this.fb.group({
      rowPosition: oldFieldData.rows[i].rowPosition,
      input: oldFieldData.rows[i].input,
      choiceOptions: this.fb.array([])
    });
    rows.push(group);
    const colLength = oldFieldData.choiceOptions.length;
    for (let j = 0; j < colLength; j++) {
      this.createViewValue(
        group.controls.choiceOptions,
        oldFieldData.choiceOptions[j].viewValue,
        oldFieldData.choiceOptions[j].optionPosition,
        isRequired
      );
    }
  }
  createViewValue(field, name, pos, isRequired) {
    const group = this.fb.group({
      ChoicePosition: pos,
      viewValue: name,
      value: false
    });
    if (isRequired) {
      group.controls.value.setValidators([Validators.required]);
    }
    field.push(group);
  }
  //

  // linear
  createRadio(fieldData, oldFieldData, isRequired) {
    const minValue = oldFieldData.minValue;
    const maxValue = oldFieldData.maxValue;
    const group = this.fb.group({
      minLabel: oldFieldData.minLabel,
      maxLabel: oldFieldData.maxLabel,
      choiceOptions: this.fb.array([])
    });
    fieldData.push(group);
    let index = 0;
    for (let i = minValue; i <= maxValue; i++) {
      this.createViewValue(
        group.controls.choiceOptions,
        i.toString(),
        index,
        isRequired
      );
      index++;
    }
  }
  inputFieldError(formGroup: FormGroup): boolean {
    const control = formGroup.controls.input;
    if (control.errors && this.showError) {
      console.log('g');
      return true;
    }
  }
  see(x) {
    console.log(x);
  }
}
