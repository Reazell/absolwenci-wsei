import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { Result } from '../models/survey-result.model';
import { SurveyService } from '../services/survey.services';
import { SharedService } from './../../../../services/shared.service';

@Component({
  selector: 'app-survey-result',
  templateUrl: './survey-result.component.html',
  styleUrls: ['./survey-result.component.scss']
})
export class SurveyResultComponent implements OnInit, OnDestroy {
  data: Result;
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
                label: undefined,
                data: ['luluu', 'cos', 'tak', 'nie'],
                backgroundColor: []
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
                label: undefined,
                data: ['dłuuuuguieieeifgig', 'fwe', '123', 'op op'],
                backgroundColor: []
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
                label: 's choice',
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
                label: 'm choice',
                data: [5, 8, 14],
                backgroundColor: '#FFCE56'
              }
            ]
          }
        },
        {
          question: 'dropdown menu',
          select: 'dropdown-menu',
          answerCount: 9,
          answerData: {
            labels: ['opc', 'op fv2', '3sdz'],
            datasets: [
              {
                label: undefined,
                data: [5, 8, 14],
                backgroundColor: ['#FF6384', '#36A2EB', '#FFCE56']
              }
            ]
          }
        },
        {
          question: 'linear',
          select: 'linear-scale',
          answerCount: 12,
          answerData: {
            labels: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10],
            datasets: [
              {
                label: 'linear',
                data: [0, 0, 0, 0, 0, 0, 0, 0, 0, 12],
                backgroundColor: '#36A2EB'
              }
            ]
          }
        },
        {
          question: 's grid',
          select: 'single-grid',
          answerCount: 15,
          answerData: {
            labels: ['wiersz 1', 'wiersz 2', 'wiersz 3'],
            datasets: [
              {
                label: 'kol 1',
                data: [5, 0, 5],
                backgroundColor: '#36A2EB'
              },
              {
                label: 'kol 2',
                data: [5, 0, 0],
                backgroundColor: '#FF6384'
              }
            ]
          }
        },
        {
          question: 'm grid',
          select: 'multiple-grid',
          answerCount: 15,
          answerData: {
            labels: ['wiersz 1', 'wiersz 2', 'wiersz 3'],
            datasets: [
              {
                label: 'kol 1',
                data: [5, 0, 5],
                backgroundColor: '#36A2EB'
              },
              {
                label: 'kol 2',
                data: [5, 0, 0],
                backgroundColor: '#FF6384'
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
        // this.sth = data.result;
        // this.createData();
        console.log(data);
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
