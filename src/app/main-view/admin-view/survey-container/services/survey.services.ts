import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Observable } from 'rxjs/Observable';
import { Subject } from '../../../../../../node_modules/rxjs/internal/Subject';
import { AppConfig } from '../../../../app.config';
import { Update } from '../models/survey-creator.models';
import { Survey } from '../models/survey.model';

@Injectable()
export class SurveyService {
  controlArray: string[];
  savedSurveys: BehaviorSubject<Survey[]> = new BehaviorSubject<Survey[]>(
    undefined
  );
  openingCreatorLoader: Subject<boolean> = new Subject<boolean>();
  // openedSurvey: any;
  filterSurveyListInput: Subject<string> = new Subject<string>();
  constructor(private http: HttpClient, private config: AppConfig) {}

  saveSurveyAnswer(survey, id) {
    const obj = {
      SurveyTitle: survey.title,
      SurveyId: id,
      Questions: survey.questions
    };
    // console.log(JSON.stringify(obj));
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
    const obj = {
      Title: survey.title,
      Questions: survey.questions
    };
    // console.log(JSON.stringify(obj));
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
    const obj = {
      surveyId: object.id,
      Title: object.Title,
      Questions: object.Questions
    };
    // console.log(JSON.stringify(obj));
    return this.http
      .put<Update>(this.config.apiUrl + '/survey', {
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
        return data;
      });
  }
  getSurveyReport(id: number): Observable<any> {
    return this.http
      .get<any>(this.config.apiUrl + '/surveyreport/' + id)
      .map(data => {
        return data;
      });
  }
  saveSurveysFromApi(): void {
    this.getAllSurveys().subscribe(data => {
      this.savedSurveys.next(data);
    });
  }
  isCreatorLoading(x: boolean): void {
    this.openingCreatorLoader.next(x);
  }
  filterSurveyList(x: string): void {
    this.filterSurveyListInput.next(x);
  }
  // openCreator(formGroup): void {
  //   this.openedSurvey = formGroup;
  // }
  // getSurveyToOpen() {
  //   return this.openedSurvey;
  // }

  saveInLocaLStorage() {}
}
