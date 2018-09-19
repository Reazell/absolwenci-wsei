import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { FormGroup } from '@angular/forms';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppConfig } from '../../app.config';
import { Survey } from '../admin-view/classes/survey.model';

@Injectable()
export class SurveyService {
  controlArray: string[];
  savedSurveys: BehaviorSubject<Survey[]> = new BehaviorSubject<Survey[]>(
    undefined
  );
  openedSurvey: any;
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
  updateSurvey(survey, id) {
    return this.http
      .put<any>(this.config.apiUrl + '/survey/' + id, {
        Title: survey.title,
        Questions: survey.questions
      })
      .map(data => {
        return data;
      });
  }
  deleteSurvey(id) {
    return this.http
      .delete<any>(this.config.apiUrl + '/survey/' + id)
      .map(data => {
        return data;
      });
  }
  getAllSurveys() {
    return this.http
      .get<Survey[]>(this.config.apiUrl + '/survey/surveys')
      .map(data => {
        return data;
      });
  }
  getSurveyWithId(id) {
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
      console.log(this.savedSurveys.value);
    });
  }

  openCreator(formGroup): void {
    this.openedSurvey = formGroup;
  }
  getSurveyToOpen() {
    return this.openedSurvey;
  }

  saveInLocaLStorage() {}
}
