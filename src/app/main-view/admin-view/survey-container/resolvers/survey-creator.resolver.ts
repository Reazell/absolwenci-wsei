import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { Survey } from '../models/survey.model';
import { SurveyService } from '../services/survey.services';

@Injectable()
export class SurveyCreatorResolver implements Resolve<Survey> {
  constructor(private surveyService: SurveyService) {}
  resolve(route: ActivatedRouteSnapshot): Observable<Survey> {
    this.surveyService.isCreatorLoading(true);
    return this.surveyService.getSurveyWithId(Number(route.params['id']));
  }
}