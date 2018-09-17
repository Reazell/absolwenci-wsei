import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { FormGroup } from '@angular/forms';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppConfig } from '../../app.config';

@Injectable()
export class SurveyService {
  controlArray: string[];
  savedSurvey: BehaviorSubject<any> = new BehaviorSubject<any>(undefined);
  openedSurvey: any;
  constructor(private http: HttpClient, private config: AppConfig) {}

  // sendSurveyEmail(survey) {
  //   return this.http
  //     .post<any>(this.config.apiUrl + '/email', {
  //       Subject: 'testowe wysyłanie',
  //       Body: survey
  //     })
  //     .map(data => {
  //       return data;
  //     });
  // }
  saveSurveyAnswer(survey, id) {
    return this.http
      .post<any>(this.config.apiUrl + '/surveyanswer/surveys', {
        SurveyTitle: survey.title,
        SurveyId: id,
        Questions: survey.questions
      })
      .map(data => {
        return data;
      });
  }
  sendSurvey(survey) {
    return this.http
      .post<any>(this.config.apiUrl + '/email/emails', {
        Subject: survey.Subject,
        Body: survey.Body
      })
      .map(data => {
        return data;
      });
  }
  createSurvey(survey) {
    return this.http
      .post<any>(this.config.apiUrl + '/survey/surveys', {
        Title: survey.title,
        Questions: survey.questions
      })
      .map(data => {
        return data;
      });
  }
  getAllSurveys() {
    return this.http.get(this.config.apiUrl + '/survey/surveys').map(data => {
      return data;
    });
  }
  getSurveyWithId(id) {
    return this.http.get(this.config.apiUrl + '/survey/' + id).map(data => {
      return data;
    });
  }
  saveSurveyToOpen(form: FormGroup): void {
    this.savedSurvey.next(form);
  }

  openCreator(formGroup): void {
    this.openedSurvey = formGroup;
  }
  getSurveyToOpen() {
    return this.openedSurvey;
  }

  saveInLocaLStorage() {}
}
