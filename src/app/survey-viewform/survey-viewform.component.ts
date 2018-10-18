import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs/Subscription';
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
  id: number;
  id2: number;
  hash: string;
  title: string;

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
          this.createQuestionData(res);
          this.title = res['title'];
          this.id = Number(this.activatedRoute.snapshot.params['id']);
          this.id2 = Number(this.activatedRoute.snapshot.params['id2']);
          this.hash = this.activatedRoute.snapshot.params['hash'];
          this.loader = true;
          this.surveyService.isCreatorLoading(false);
          if (!this.id2) {
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
    this.surveyService
      .saveSurveyAnswer(
        this.invoiceForm.getRawValue(),
        this.id,
        this.hash,
        this.id2
      )
      .subscribe(
        data => {
          console.log(data);
        },
        error => {
          console.log(error);
        }
      );
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
    if (!this.id2) {
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
    data.questionTemplates.forEach(question => {
      this.createQuestion(question);
    });
  }

  createQuestion(question) {
    const control: FormArray = this.invoiceForm.get(`questions`) as FormArray;
    const group = this.addRows(question);
    control.push(group);
  }

  addRows(question) {
    const group = this.fb.group({
      content: [question.content || this.defaultQuestion],
      select: [question.select],
      QuestionPosition: [question.questionPosition],
      FieldData: this.fb.array([])
    });
    this.createFieldData(question, group.controls);
    return group;
  }

  createFieldData(question, controls) {
    question.fieldDataTemplates.forEach(data => {
      this.addGroup(controls.FieldData, controls.select.value, data);
    });
  }

  addGroup(FieldData, select: string, data) {
    switch (select) {
      case 'short-answer':
      case 'long-answer':
        this.addInput(FieldData);
        break;
      case 'linear-scale':
        this.createRadio(FieldData, data);
        break;
      case 'dropdown-menu':
      case 'single-choice':
      case 'multiple-choice':
        // this.addCheckField(FieldData, data);
        this.addArray(FieldData, data);
        break;
      case 'single-grid':
      case 'multiple-grid':
        this.createRow(FieldData, data);
        break;
    }
  }

  addArray(FieldData, data) {
    const group = this.fb.group({
      choiceOptions: this.fb.array([])
    });
    FieldData.push(group);
    data.choiceOptions.forEach(choiceOptions => {
      // this.addCheckField(group.controls.choiceOptions, choiceOptions);
      this.createViewValue(
        group.controls.choiceOptions,
        choiceOptions.viewValue,
        choiceOptions.optionPosition
      );
    });
  }
  addInput(FieldData) {
    const group = this.fb.group({
      input: ['']
    });
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
  createRow(fieldData, oldFieldData) {
    const group = this.fb.group({
      rows: this.fb.array([])
    });
    fieldData.push(group);
    const rowLength = oldFieldData.rows.length;

    for (let i = 0; i < rowLength; i++) {
      this.createGrid(group.controls.rows, oldFieldData, i);
    }
  }

  createGrid(rows, oldFieldData, i) {
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
        oldFieldData.choiceOptions[j].optionPosition
      );
    }
  }
  createViewValue(field, name, pos) {
    const group = this.fb.group({
      ChoicePosition: pos,
      viewValue: name,
      value: false
    });
    field.push(group);
  }
  //

  // linear
  createRadio(fieldData, oldFieldData) {
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
      this.createViewValue(group.controls.choiceOptions, i.toString(), index);
      index++;
    }
  }
}
