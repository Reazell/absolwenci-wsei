import { Injectable, OnDestroy } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { SurveyService } from '../services/survey.services';

@Injectable()
export class SurveyCreatorResolver implements Resolve<any>, OnDestroy {
  // surveyIDSub: Subscription;
  constructor(private surveyService: SurveyService) {}
  resolve(route: ActivatedRouteSnapshot) {
    // this.surveyIDSub = this.activatedRoute.params.subscribe(params => {
    //   this.surveyService
    //     .getSurveyWithId(Number(params['id']))
    //     .subscribe(data => {
    //       return data;
    //     },error => {

    //     });
    // });
    console.log(Number(route.params['id']));

    return this.surveyService.getSurveyWithId(Number(route.params['id']));
  }
  ngOnDestroy() {
    // this.surveyIDSub.unsubscribe();
  }
}
