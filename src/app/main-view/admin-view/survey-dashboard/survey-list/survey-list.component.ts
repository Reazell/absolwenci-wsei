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

  ngOnInit(): void {
    this.getAllSurveys();
    this.isLoadingFromOutside();
    this.filterSurveyList();
  }
  saveSurveysFromApi(): void {
    this.surveyService.saveSurveysFromApi();
  }
  filterSurveyList(): void {
    this.surveyService.filterSurveyListInput.subscribe(data => {
      // this.surveyArr.filter(filtered => console.log(filtered));
      this.surveyArr.filter(sth => {
        console.log(data);
        console.log(sth);
      });
    });
  }
  isLoadingFromOutside(): void {
    this.isLoadingSub = this.surveyService.openingCreatorLoader.subscribe(
      data => {
        this.loading = data;
      }
    );
  }
  getAllSurveys(): void {
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
  // subToObs() {
  //   this.updateToApi$
  //     .pipe(
  //       debounceTime(300),
  //       switchMap(() => this.updateSurvey())
  //     )
  //     .subscribe(res => {
  //       console.log(res);
  //     });
  // }
  openCreator(survey): void {
    this.loading = true;
    this.router.navigateByUrl('/app/admin/survey/create/' + survey.id);
  }
  openResult(survey): void {
    this.loading = true;
    this.router.navigateByUrl('/app/admin/survey/result/' + survey.id);
  }

  deleteSurvey(id: number): void {
    this.surveyService.deleteSurvey(id).subscribe(
      () => {
        this.saveSurveysFromApi();
      },
      error => {
        console.log(error);
      }
    );
  }
  ngOnDestroy(): void {
    this.loading = false;
  }
}
