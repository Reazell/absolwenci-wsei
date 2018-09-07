import { FormBuilder, FormGroup } from '@angular/forms';
import { SurveyService } from '../../services/survey.services';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-survey-viewform',
  templateUrl: './survey-viewform.component.html',
  styleUrls: ['./survey-viewform.component.scss']
})
export class SurveyViewformComponent implements OnInit, OnDestroy {
  invoiceForm: FormGroup;
  oldData;
  rows = [
    {
      input: 'row 0'
    },
    {
      input: 'row 1'
    }
  ];
  cols = [
    {
      input: 'col 0'
    },
    {
      input: 'col 1'
    }
  ];
  constructor(
    private surveyService: SurveyService,
    private fb: FormBuilder,
    private router: Router
  ) {}

  ngOnInit() {
    this.surveyService.savedSurvey.subscribe(data => {
      if (data) {
        console.log(data);
        this.makeSth(data);
      }
    });
  }

  ngOnDestroy() {
    this.surveyService.saveSurvey(undefined);
    this.oldData = undefined;
    this.invoiceForm = undefined;
  }

  updateSelection(radios, radio, e) {
    console.log(radios);
    radios.forEach(el => {
      el.controls.value.setValue(false);
    });
    radio.setValue(true);
    e.source.checked = true;
  }

  sth(f) {
    console.log(f);
  }

  makeSth(data) {
    this.invoiceForm = data;
    console.log(this.invoiceForm.controls.QuestionData['controls']);
    const select = this.invoiceForm.controls.QuestionData['controls'][0]
      .controls.select.value;
    const fieldData = this.invoiceForm.controls.QuestionData['controls'][0]
      .controls.FieldData;
    this.oldData = fieldData.getRawValue();
    this.oldData.forEach(oldFieldData => {
      if (select === 'single-grid' || select === 'multiple-grid') {
        fieldData.removeAt(0);
        this.createRow(fieldData, oldFieldData);
      }
    });
  }
  // rows
  createRow(fieldData, oldFieldData) {
    const group = this.fb.group({
      rows: this.fb.array([])
    });
    fieldData.push(group);
    const rowLength = oldFieldData.rows.length;

    for (let i = 0; i < rowLength; i++) {
      this.createGrid(group.controls.rows, oldFieldData);
    }
  }

  createGrid(rows, oldFieldData) {
    const group = this.fb.group({
      input: 'row 0',
      column: this.fb.array([])
    });
    // return group;
    rows.push(group);
    const colLength = oldFieldData.columns.length;
    for (let i = 0; i < colLength; i++) {
      this.createCol(group.controls.column);
    }
  }
  createCol(column) {
    const group = this.fb.group({
      viewValue: 'col 0',
      value: false
    });
    // return group;
    column.push(group);
  }
}
