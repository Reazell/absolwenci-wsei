import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { SurveyService } from '../services/survey.services';

@Component({
  selector: 'app-survey-result',
  templateUrl: './survey-result.component.html',
  styleUrls: ['./survey-result.component.scss']
})
export class SurveyResultComponent implements OnInit, OnDestroy {
  data;
  sth;
  id: number;
  // subs
  getResultsSub: Subscription;
  surveyIDSub: Subscription;

  constructor(
    private surveyService: SurveyService,
    private activatedRoute: ActivatedRoute
  ) {
    this.data = {
      labels: ['A', 'B', 'C'],
      datasets: [
        {
          data: [300, 50, 100],
          backgroundColor: ['#FF6384', '#36A2EB', '#FFCE56']
          // hoverBackgroundColor: ['#FF6384', '#36A2EB', '#FFCE56']
        }
      ]
    };
  }

  ngOnInit() {
    this.getSurveyId();
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
  createData() {
    // this.sth.forEach(el => {
    // });
  }
  ngOnDestroy() {
    this.getResultsSub.unsubscribe();
    this.surveyIDSub.unsubscribe();
  }
}
