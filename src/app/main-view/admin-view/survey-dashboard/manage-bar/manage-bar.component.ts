import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SurveyService } from './../../survey-container/services/survey.services';

@Component({
  selector: 'app-manage-bar',
  templateUrl: './manage-bar.component.html',
  styleUrls: ['./manage-bar.component.scss']
})
export class ManageBarComponent implements OnInit {
  constructor(private router: Router, private surveyService: SurveyService) {}

  ngOnInit() {}
  redirectToNew(): void {
    this.surveyService.isCreatorLoading(true);
    const obj = {
      title: '',
      questions: []
    };
    this.surveyService.createSurvey(obj).subscribe(
      data => {
        console.log(data);
        const string: string = '/app/admin/survey/create/' + data;
        this.router.navigateByUrl(string);
        this.surveyService.isCreatorLoading(false);
      },
      error => {
        console.log(error);
      }
    );
  }

  searchSurveyList(searchString: string): void {
    this.surveyService.filterSurveyList(searchString);
  }
}
