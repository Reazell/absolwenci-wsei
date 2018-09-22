import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { SurveyService } from '../services/survey.services';
import { SharedService } from './../../../../services/shared.service';

@Component({
  selector: 'app-survey-result',
  templateUrl: './survey-result.component.html',
  styleUrls: ['./survey-result.component.scss']
})
export class SurveyResultComponent implements OnInit, OnDestroy {
  data;
  data2;
  sth;
  id: number;
  // subs
  getResultsSub: Subscription;
  surveyIDSub: Subscription;

  constructor(
    private surveyService: SurveyService,
    private sharedService: SharedService,
    private activatedRoute: ActivatedRoute
  ) {
    this.data2 = {
      labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July'],
      datasets: [
        {
          label: 'My First dataset',
          backgroundColor: '#42A5F5',
          borderColor: '#1E88E5',
          data: [65, 59, 80, 81, 56, 55, 40]
        },
        {
          label: 'My Second dataset',
          backgroundColor: '#9CCC65',
          borderColor: '#7CB342',
          data: [28, 48, 40, 19, 86, 27, 90]
        }
      ]
    };
    this.createData();
    console.log(this.data);
  }
  createData() {
    this.data = {
      title: 'coś tam',
      totalAnswerCount: 30,
      questionsData: [
        {
          question: 'short',
          select: 'short-answer',
          answerCount: 15,
          answerData: {
            labels: [],
            datasets: [
              {
                data: ['luluu', 'cos', 'tak', 'nie']
              }
            ]
          }
        },
        {
          question: 'long',
          select: 'long-answer',
          answerCount: 1,
          answerData: {
            labels: [],
            datasets: [
              {
                data: ['dłuuuuguieieeifgig', 'fwe', '123', 'op op']
              }
            ]
          }
        },
        {
          question: 's choice',
          select: 'single-choice',
          answerCount: 4,
          answerData: {
            labels: ['opcja 1', 'opcja 2', 'opcja 3'],
            datasets: [
              {
                label: 'sth',
                data: [2, 3, 4],
                backgroundColor: '#FF6384'
              }
            ]
          }
        },
        {
          question: 'm choice',
          select: 'multiple-choice',
          answerCount: 6,
          answerData: {
            labels: ['opcja 1fv', 'opcja fv2', 'opcja 3csdz'],
            datasets: [
              {
                label: 'sth',
                data: [5, 8, 14],
                backgroundColor: '#FFCE56'
              }
            ]
          }
        }
      ]
    };
  }
  ngOnInit() {
    this.getSurveyId();
    this.sharedService.showBackButton(true);
  }
  getSurveyId(): void {
    this.surveyIDSub = this.activatedRoute.params.subscribe(params => {
      this.id = Number(params['id']);
      this.getSurveyReport();
    });
  }
  getSurveyReport() {
    this.getResultsSub = this.surveyService.getSurveyReport(this.id).subscribe(
      data => {
        this.sth = data.result;
        this.createData();
        console.log(data.result);
      },
      error => {
        console.log(error);
      }
    );
  }
  ngOnDestroy() {
    this.getResultsSub.unsubscribe();
    this.surveyIDSub.unsubscribe();
    this.sharedService.showBackButton(false);
  }
  see(x) {
    console.log(x);
  }
}
