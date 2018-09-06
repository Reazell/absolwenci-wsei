import { FormBuilder, FormGroup } from '@angular/forms';
import { SurveyService } from './../../services/survey.services';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '../../../../../node_modules/@angular/router';

@Component({
  selector: 'app-survey-viewform',
  templateUrl: './survey-viewform.component.html',
  styleUrls: ['./survey-viewform.component.scss']
})
export class SurveyViewformComponent implements OnInit, OnDestroy {
  invoiceForm: FormGroup;
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
    // this.invoiceForm = this.surveyService.getSurvey();
    // console.log(this.invoiceForm);
    this.surveyService.savedSurvey.subscribe(data => {
      if (data) {
        this.makeSth(data);
      } else {
        // this.invoiceForm = this.fb.group({});
        this.router.navigateByUrl('app/admin/create');
      }
    });
    // this.rows.forEach(row => {
    //   // row.input
    //   this.cols.forEach(col => {
    //     // col.input
    //     // radio.value
    //   });
    // });
  }

  ngOnDestroy() {
    this.surveyService.saveSurvey(undefined);
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
    // console.log(
    //   this.invoiceForm.controls.QuestionData['controls'][0].controls.FieldData
    //     .controls[0]
    // );
    const fieldData = this.invoiceForm.controls.QuestionData['controls'][0]
      .controls.FieldData;

    fieldData.removeAt(0);
    fieldData.push(this.createRow());
  }
  // rows
  createRow() {
    const group = this.fb.group({
      rows: this.fb.array([this.createGrid(), this.createGrid()])
    });
    return group;
  }
  createGrid() {
    const group = this.fb.group({
      input: 'row 0',
      column: this.fb.array([this.createCol(), this.createCol()])
    });
    return group;
  }
  createCol() {
    const group = this.fb.group({
      viewValue: 'col 0',
      value: false
    });
    return group;
  }
}
