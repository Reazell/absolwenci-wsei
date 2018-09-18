import { SurveyService } from '../../services/survey.services';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-survey-list',
  templateUrl: './survey-list.component.html',
  styleUrls: ['./survey-list.component.scss']
})
export class SurveyListComponent implements OnInit {
  // subs
  getAllSurveysSub;

  surveyArr;
  constructor(private surveyService: SurveyService, private router: Router) {}

  ngOnInit() {
    // this.surveyArr = JSON.parse(localStorage.getItem('surveys'));
    this.getAllSurveys();
  }
  getAllSurveys() {
    this.getAllSurveysSub = this.surveyService.getAllSurveys().subscribe(
      data => {
        this.surveyArr = data;
        // console.log(this.surveyArr);
      },
      error => {
        console.log(error);
      }
    );
  }
  openCreator(survey) {
    // [routerLink]="['/app/admin/create']"
    this.surveyService.openCreator(survey);
    this.router.navigateByUrl('/app/admin/create/' + survey.id);
  }

  deleteSurvey(id) {
    this.surveyService.deleteSurvey(id).subscribe(
      data => {
        console.log(data);
        this.getAllSurveys();
      },
      error => {
        console.log(error);
      }
    );
  }
}
