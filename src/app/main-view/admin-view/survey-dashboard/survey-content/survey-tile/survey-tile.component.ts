import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { SurveyModel } from '../../../survey-container/models/survey.model';
import { SurveyService } from './../../../survey-container/services/survey.services';

@Component({
  selector: 'app-survey-tile',
  templateUrl: './survey-tile.component.html',
  styleUrls: ['./survey-tile.component.scss']
})
export class SurveyTileComponent implements OnInit {
  @Input()
  survey;
  @Output()
  openCreator: EventEmitter<boolean> = new EventEmitter<boolean>();
  surveyModel: SurveyModel;
  constructor(private surveyService: SurveyService) {}

  ngOnInit() {
    this.surveyModel = new SurveyModel(this.survey);
  }
  openCreatorClick() {
    this.surveyService.isCreatorLoading(true);
    this.openCreator.emit(true);
  }
}
