import { Component, Input, OnInit } from '@angular/core';
import { SurveyModel } from '../../../../survey-container/models/survey.model';

@Component({
  selector: 'app-survey-tile',
  templateUrl: './survey-tile.component.html',
  styleUrls: ['./survey-tile.component.scss']
})
export class SurveyTileComponent implements OnInit {
  @Input()
  survey;

  surveyModel: SurveyModel;
  constructor() {}

  ngOnInit() {
    this.surveyModel = new SurveyModel(this.survey);
  }
}
