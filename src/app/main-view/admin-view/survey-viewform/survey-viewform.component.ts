import { FormBuilder, FormGroup } from '@angular/forms';
import { SurveyService } from '../../services/survey.services';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';

@Component({
  selector: 'app-survey-viewform',
  templateUrl: './survey-viewform.component.html',
  styleUrls: ['./survey-viewform.component.scss']
})
export class SurveyViewformComponent implements OnInit, OnDestroy {
  invoiceForm: FormGroup;
  // disabled = false;
  oldData;

  constructor(
    private surveyService: SurveyService,
    private fb: FormBuilder,
    private router: Router
  ) {}

  ngOnInit() {
    this.surveyService.savedSurvey.subscribe(data => {
      if (data) {
        this.createQuestionData(data);
      }
    });
  }

  ngOnDestroy() {
    // this.surveyService.saveSurvey(undefined);
    // this.oldData = undefined;
    // this.invoiceForm = undefined;
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
    this.invoiceForm = data;
    const questionData = this.invoiceForm.controls.QuestionData['controls'];
    questionData.forEach(question => {
      this.createQuestion(question);
    });
  }
  createQuestion(question) {
    const select = question.controls.select.value;
    const fieldData = question.controls.FieldData;
    this.oldData = fieldData.getRawValue();
    this.oldData.forEach(oldFieldData => {
      let length;
      switch (select) {
        case 'short-answer':
        case 'long-answer':
          length = fieldData.controls.length;
          for (let i = 0; i < length; i++) {
            fieldData.controls[i].controls.input.enable();
          }
          break;
        case 'single-choice':
        case 'multiple-choice':
          console.log(this.invoiceForm.controls.QuestionData['controls']);
          length = fieldData.controls.length;
          for (let i = 0; i < length; i++) {
            fieldData.controls[i].controls.value.enable();
          }
          break;
        case 'single-grid':
        case 'multiple-grid':
          fieldData.removeAt(0);
          this.createRow(fieldData, oldFieldData);
          break;
        case 'linear-scale':
          fieldData.removeAt(0);
          this.createRadio(fieldData, oldFieldData);
          break;
        case 'dropdown-menu':
          // this.addValue(fieldData);
          const fieldDataArr = fieldData.controls[0].controls.input.controls;
          fieldDataArr.forEach(field => {
            field.controls.value.enable();
          });
          break;
      }
    });
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
