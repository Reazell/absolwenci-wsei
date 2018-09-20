import { SurveyModel } from '../../classes/survey.model';
import { Component, OnInit, Input } from '@angular/core';

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
