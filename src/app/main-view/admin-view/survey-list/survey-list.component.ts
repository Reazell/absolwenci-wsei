import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-survey-list',
  templateUrl: './survey-list.component.html',
  styleUrls: ['./survey-list.component.scss']
})
export class SurveyListComponent implements OnInit {
  surveyArr = [];
  constructor() {}

  ngOnInit() {
    this.surveyArr = JSON.parse(localStorage.getItem('surveys'));
    console.log(this.surveyArr);
  }
}
