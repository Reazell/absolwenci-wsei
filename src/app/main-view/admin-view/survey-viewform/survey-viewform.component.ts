import { FormBuilder, FormGroup, FormArray } from '@angular/forms';
import { SurveyService } from '../../services/survey.services';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { SharedService } from '../../../services/shared.service';

@Component({
  selector: 'app-survey-viewform',
  templateUrl: './survey-viewform.component.html',
  styleUrls: ['./survey-viewform.component.scss']
})
export class SurveyViewformComponent implements OnInit, OnDestroy {
  invoiceForm: FormGroup;

  // subs
  sendSurveySub;

  // disabled = false;
  oldData;
  data = {
    Form_Title: 'Formularz bez nazwy',
    Created_Date: '14.09.2018',
    Created_Time: '11:46:12',
    QuestionData: [
      {
        question: '',
        select: 'single-choice',
        lastSelect: null,
        FieldData: [{ value: false, viewValue: 'opcja 0' }]
      },
      {
        question: '',
        select: 'single-choice',
        lastSelect: null,
        FieldData: [{ value: false, viewValue: 'opcja 1' }]
      }
    ]
  };
  constructor(
    private surveyService: SurveyService,
    private fb: FormBuilder,
    private router: Router,
    private sharedService: SharedService
  ) {}

  ngOnInit() {
    this.surveyService.savedSurvey.subscribe(data => {
      if (data) {
        this.createQuestionData(data);
      }
    });
    this.sendSurvey();
    this.sharedService.showSendButton(true);
  }
  sendSurvey() {
    this.sendSurveySub = this.sharedService.sendButton.subscribe(() => {
      // this.onSubmit();
      console.log('sent!');
    });
  }
  ngOnDestroy() {
    this.sharedService.showSendButton(false);
    this.sendSurveySub.unsubscribe();
  }

  updateSelection(radios, radio, e?) {
    radios.forEach(el => {
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
      question: [question.question],
      select: [question.select],
      lastSelect: [undefined],
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
      case 'dropdown-menu':
        this.addArray(FieldData, data);
        break;
      case 'linear-scale':
        this.createRadio(FieldData, data);
        break;
      case 'single-choice':
      case 'multiple-choice':
        this.addCheckField(FieldData, data);
        break;
      case 'single-grid':
      case 'multiple-grid':
        this.createRow(FieldData, data);
        break;
    }
  }

  addArray(FieldData, data) {
    const group = this.fb.group({
      input: this.fb.array([])
    });
    FieldData.push(group);
    data.input.forEach(input => {
      this.addCheckField(group.controls.input, input);
    });
  }
  addInput(FieldData) {
    const group = this.fb.group({
      input: ['']
    });
    FieldData.push(group);
  }
  addCheckField(selectArr, data) {
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
      this.createGrid(
        group.controls.rows,
        oldFieldData,
        oldFieldData.rows[i].input
      );
    }
  }

  createGrid(rows, oldFieldData, name) {
    console.log(oldFieldData);
    const group = this.fb.group({
      input: name,
      column: this.fb.array([])
    });
    rows.push(group);
    const colLength = oldFieldData.columns.length;
    for (let i = 0; i < colLength; i++) {
      this.createViewValue(
        group.controls.column,
        oldFieldData.columns[i].viewValue
      );
    }
  }
  createViewValue(field, name) {
    const group = this.fb.group({
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
      radios: this.fb.array([])
    });
    fieldData.push(group);
    for (let i = minValue; i <= maxValue; i++) {
      this.createViewValue(group.controls.radios, i.toString());
    }
  }
}
