import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { FormGroup } from '@angular/forms';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppConfig } from '../../app.config';

@Injectable()
export class SurveyService {
  controlArray: string[];
  savedSurvey: BehaviorSubject<any> = new BehaviorSubject<any>(undefined);
  constructor(private http: HttpClient, private config: AppConfig) {}

  sendSurveyEmail(survey) {
    return this.http
      .post<any>(this.config.apiUrl + '/email', {
        Subject: 'testowe wysyłanie',
        Body: survey
      })
      .map(data => {
        return data;
      });
  }

  saveSurvey(form: FormGroup): void {
    this.savedSurvey.next(form);
  }
  sendSurvey(survey) {
    return this.http
      .post<any>(this.config.apiUrl + '/email', {
        Subject: 'testowe wysyłanie',
        Body: survey
      })
      .map(data => {
        return data;
      });
  }
  createSurvey() {
    return this.http
      .post<any>(this.config.apiUrl + '/survey/surveys', {
        Title: 'testowy tytuł'
      })
      .map(data => {
        return data;
      });
  }
}
