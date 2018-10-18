import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { SurveyService } from '../services/survey.services';

@Injectable()
export class SurveyViewformResolver implements Resolve<any> {
  constructor(private surveyService: SurveyService) {}
  resolve(route: ActivatedRouteSnapshot): Observable<any> {
    this.surveyService.isCreatorLoading(true);
    const id = Number(route.params['id']);
    const id2 = Number(route.params['id2']);
    if (id2) {
      return this.surveyService.getSurveyWithIdAndHash(
        id,
        route.params['hash'],
        id2
      );
    } else {
      return this.surveyService.getSurveyWithId(id);
    }
  }
}
