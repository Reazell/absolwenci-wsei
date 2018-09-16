import { FormBuilder, FormGroup, FormArray } from '@angular/forms';
import { SurveyService } from '../../services/survey.services';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, NavigationEnd, ActivatedRoute } from '@angular/router';
import { SharedService } from '../../../services/shared.service';

@Component({
  selector: 'app-survey-viewform',
  templateUrl: './survey-viewform.component.html',
  styleUrls: ['./survey-viewform.component.scss']
})
export class SurveyViewformComponent implements OnInit, OnDestroy {
  invoiceForm: FormGroup;
  defaultQuestion = 'Brak pytania';
  id: number;

  // subs
  sendSurveySub;
  savedSurveySub;
  surveyIDSub;

  constructor(
    private surveyService: SurveyService,
    private fb: FormBuilder,
    private router: Router,
    private sharedService: SharedService,
    private activatedRoute: ActivatedRoute
  ) {}

  ngOnInit() {
    this.getSurveyId();
    // this.getSavedSurvey();
    this.sendSurvey();
    this.sharedService.showSendButton(true);
  }
  getSurveyId() {
    this.surveyIDSub = this.activatedRoute.params.subscribe(params => {
      this.id = params['id'];
      this.getSurvey();
    });
  }
  // getSavedSurvey() {
  //   this.savedSurveySub = this.surveyService.savedSurvey.subscribe(data => {
  //     if (data) {
  //       this.createQuestionData(data);
  //     }
  //   });
  // }
  getSurvey() {
    const surveyArr = JSON.parse(localStorage.getItem('surveys')) || [];
    if (this.id !== undefined) {
      for (let i = 0; i < length; i++) {
        if (surveyArr[i].id === this.id) {
          this.createQuestionData(surveyArr[i].content);
          break;
        }
      }
    }
  }
  sendSurvey() {
    this.sendSurveySub = this.sharedService.sendButton.subscribe(() => {
      // this.onSubmit();
      console.log(JSON.stringify(this.invoiceForm.getRawValue()));
    });
  }
  ngOnDestroy() {
    this.sharedService.showSendButton(false);
    this.sendSurveySub.unsubscribe();
    this.savedSurveySub.unsubscribe();
  }

  updateSelection(choiceOptions, radio, e?) {
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
      Form_Title: [data.Form_Title],
      Created_Date: [data.Created_Date],
      Created_Time: [data.Created_Time],
      QuestionData: this.fb.array([])
    });
    data.QuestionData.forEach(question => {
      this.createQuestion(question);
    });
  }

  createQuestion(question) {
    const control: FormArray = this.invoiceForm.get(
      `QuestionData`
    ) as FormArray;
    const group = this.addRows(question);
    control.push(group);
  }

  addRows(question) {
    const group = this.fb.group({
      question: [question.question || this.defaultQuestion],
      select: [question.select],
      QuestionPosition: [question.QuestionPosition],
      FieldData: this.fb.array([])
    });
    this.createFieldData(question, group.controls);
    return group;
  }

  createFieldData(question, controls) {
    question.FieldData.forEach(data => {
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
        choiceOptions.ChoicePosition
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
    console.log();
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
      RowPosition: oldFieldData.rows[i].RowPosition,
      input: oldFieldData.rows[i].input,
      choiceOptions: this.fb.array([])
    });
    rows.push(group);
    const colLength = oldFieldData.columns.length;
    for (let j = 0; j < colLength; j++) {
      this.createViewValue(
        group.controls.choiceOptions,
        oldFieldData.columns[j].viewValue,
        oldFieldData.columns[j].ChoicePosition
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
