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
    // [routerLink]="['/app/admin/survey/create/']"
    this.router.navigateByUrl('/app/admin/survey/create/');
    //   const obj = {
    //     title: '',
    //     questions: []
    //   };
    //   this.surveyService.createSurvey(obj).subscribe(
    //     data => {
    //       console.log(data);
    //       const string: string = '/app/admin/survey/create/' + data.id;
    //       this.router.navigateByUrl(string);
    //     },
    //     error => {
    //       console.log(error);
    //     }
    //   );
  }
}
