import { SurveyService } from '../../services/survey.services';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-survey-list',
  templateUrl: './survey-list.component.html',
  styleUrls: ['./survey-list.component.scss']
})
export class SurveyListComponent implements OnInit {
  surveyArr = [];
  constructor(private surveyService: SurveyService, private router: Router) {}

  ngOnInit() {
    this.surveyArr = JSON.parse(localStorage.getItem('surveys'));
    // console.log(this.surveyArr);
  }

  openCreator(survey) {
    // [routerLink]="['/app/admin/create']"
    this.surveyService.openCreator(survey);
    this.router.navigateByUrl('/app/admin/create');
  }
  deleteSurvey(id) {
    const length = this.surveyArr.length;
    for (let i = 0; i < length; i++) {
      if (id === this.surveyArr[i].id) {
        this.surveyArr.splice(i, 1);
        localStorage.setItem('surveys', JSON.stringify(this.surveyArr));
        break;
      }
    }
  }
}
