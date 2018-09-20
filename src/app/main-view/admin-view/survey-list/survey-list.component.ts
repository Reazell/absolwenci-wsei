import { Survey } from './../classes/survey.model';
import { SurveyService } from './../../services/survey.services';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from '../../../../../node_modules/rxjs/Subscription';

@Component({
  selector: 'app-survey-list',
  templateUrl: './survey-list.component.html',
  styleUrls: ['./survey-list.component.scss']
})
export class SurveyListComponent implements OnInit {
  // subs
  getAllSurveysSub: Subscription;

  surveyArr: Survey[];
  constructor(private surveyService: SurveyService, private router: Router) {}

  ngOnInit() {
    // this.surveyArr = JSON.parse(localStorage.getItem('surveys'));
    this.saveSurveysFromApi();
    this.getAllSurveys();
  }
  saveSurveysFromApi() {
    this.surveyService.saveSurveysFromApi();
  }
  getAllSurveys() {
    this.getAllSurveysSub = this.surveyService.savedSurveys.subscribe(
      data => {
        this.surveyArr = data;
      },
      error => {
        console.log(error);
      }
    );
  }
  openCreator(survey) {
    this.router.navigateByUrl('/app/admin/create/' + survey.id);
  }

  deleteSurvey(id) {
    this.surveyService.deleteSurvey(id).subscribe(
      data => {
        this.saveSurveysFromApi();
      },
      error => {
        console.log(error);
      }
    );
  }
}
