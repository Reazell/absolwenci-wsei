import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppConfig } from '../../app.config';

@Injectable()
export class SurveyService {
  controlArray: string[];
  constructor(private http: HttpClient, private config: AppConfig) {}

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
}
