import { Observable } from 'rxjs/Observable';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { FormGroup } from '@angular/forms';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppConfig } from '../../app.config';
import { Survey, Update } from '../admin-view/classes/survey.model';

@Injectable()
export class SurveyService {
  controlArray: string[];
  savedSurveys: BehaviorSubject<Survey[]> = new BehaviorSubject<Survey[]>(
    undefined
  );
  // openedSurvey: any;
  constructor(private http: HttpClient, private config: AppConfig) {}

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
  updateSurvey(object: Update): Observable<any> {
    console.log(JSON.stringify(object.id));
    return this.http
      .put<Update>(this.config.apiUrl + '/survey/' + object.id, {
        surveyId: object.id,
        Title: object.Title,
        Questions: object.Questions
      })
      .map(data => {
        return data;
      });
  }
  deleteSurvey(id: number) {
    return this.http
      .delete<any>(this.config.apiUrl + '/survey/' + id)
      .map(data => {
        return data;
      });
  }
  getAllSurveys(): Observable<Survey[]> {
    return this.http
      .get<Survey[]>(this.config.apiUrl + '/survey/surveys')
      .map(data => {
        return data;
      });
  }
  getSurveyWithId(id: number): Observable<Survey> {
    return this.http
      .get<Survey>(this.config.apiUrl + '/survey/' + id)
      .map(data => {
        // return this.http.get(this.config.apiUrl + '/survey/' + id).map(data => {
        return data;
      });
  }
  saveSurveysFromApi(): void {
    this.getAllSurveys().subscribe(data => {
      this.savedSurveys.next(data);
    });
  }

  // openCreator(formGroup): void {
  //   this.openedSurvey = formGroup;
  // }
  // getSurveyToOpen() {
  //   return this.openedSurvey;
  // }

  saveInLocaLStorage() {}
}
