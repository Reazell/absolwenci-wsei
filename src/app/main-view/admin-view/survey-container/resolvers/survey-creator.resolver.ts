import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { SurveyService } from '../services/survey.services';
import { Survey } from './../models/survey.model';

@Injectable()
export class SurveyCreatorResolver implements Resolve<Survey> {
  constructor(private surveyService: SurveyService) {}
  resolve(route: ActivatedRouteSnapshot): Observable<Survey> {
    return this.surveyService.getSurveyWithId(Number(route.params['id']));
  }
}
