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
    const hash =  route.params['hash'];
    if (hash) {
      return this.surveyService.getSurveyWithIdAndHash(
        id,
       hash
      );
    } else {
      return this.surveyService.getSurveyWithId(id);
    }
  }
}
