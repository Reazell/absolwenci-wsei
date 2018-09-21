import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs/Subscription';
import { Survey } from '../../survey-container/models/survey.model';
import { SurveyService } from '../../survey-container/services/survey.services';

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
        if (data) {
          this.surveyArr = data.reverse();
        }
      },
      error => {
        console.log(error);
      }
    );
  }
  openCreator(survey) {
    console.log(survey);
    this.router.navigateByUrl('/app/admin/survey/create/' + survey.id);
  }
  openResult(survey) {
    console.log(survey);
    this.router.navigateByUrl('/app/admin/survey/result/' + survey.id);
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
