import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs/Subscription';
import { Survey } from '../../survey-container/models/survey.model';
import { SurveyService } from '../../survey-container/services/survey.services';

@Component({
  selector: 'app-survey-list',
  templateUrl: './survey-list.component.html',
  styleUrls: ['./survey-list.component.scss']
})
export class SurveyListComponent implements OnInit, OnDestroy {
  loading = false;
  // subs
  getAllSurveysSub: Subscription;
  isLoadingSub: Subscription;
  surveyArr: Survey[];
  constructor(private surveyService: SurveyService, private router: Router) {}

  ngOnInit() {
    this.getAllSurveys();
    this.isLoadingFromOutside();
  }
  saveSurveysFromApi() {
    this.surveyService.saveSurveysFromApi();
  }
  isLoadingFromOutside() {
    this.isLoadingSub = this.surveyService.openingCreatorLoader.subscribe(
      data => {
        this.loading = data;
      }
    );
  }
  getAllSurveys() {
    this.saveSurveysFromApi();
    this.getAllSurveysSub = this.surveyService.savedSurveys.subscribe(
      data => {
        if (data) {
          this.surveyArr = data;
        }
      },
      error => {
        console.log(error);
      }
    );
  }
  openCreator(survey) {
    this.loading = true;
    this.router.navigateByUrl('/app/admin/survey/create/' + survey.id);
  }
  openResult(survey) {
    this.loading = true;
    this.router.navigateByUrl('/app/admin/survey/result/' + survey.id);
  }

  deleteSurvey(id) {
    this.surveyService.deleteSurvey(id).subscribe(
      () => {
        this.saveSurveysFromApi();
      },
      error => {
        console.log(error);
      }
    );
  }
  ngOnDestroy() {
    this.loading = false;
  }
}
