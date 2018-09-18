import { SurveyModel } from './../../classes/survey.model';
import { Component, OnInit, Input, AfterViewInit } from '@angular/core';

@Component({
  selector: 'app-survey-tile',
  templateUrl: './survey-tile.component.html',
  styleUrls: ['./survey-tile.component.scss']
})
export class SurveyTileComponent implements OnInit, AfterViewInit {
  @Input()
  survey;

  surveyModel: SurveyModel;
  constructor() {}

  ngOnInit() {
    this.surveyModel = new SurveyModel(this.survey);
    console.log(this.surveyModel);
    console.log(this.survey);
  }
  ngAfterViewInit() {
    // const date = createdAt
  }
}
