import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { Survey } from '../models/survey.model';
import { SurveyService } from '../services/survey.services';

@Injectable()
export class SurveyViewformResolver implements Resolve<any> {
  constructor(private surveyService: SurveyService) {}
  resolve(route: ActivatedRouteSnapshot): Observable<any> {
    this.surveyService.isCreatorLoading(true);
    return this.surveyService.getSurveyWithIdAndHash(
      Number(route.params['id']),
      route.params['hash'],
      Number(route.params['id2'])
    );
  }
}
