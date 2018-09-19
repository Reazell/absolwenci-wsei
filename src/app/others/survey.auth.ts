import { SurveyService } from '../main-view/services/survey.services';
import { Injectable, OnInit } from '@angular/core';
import { Router, CanLoad } from '@angular/router';

@Injectable()
export class SurveyGuard implements CanLoad {
  bool = false;
  constructor(private router: Router, private surveyService: SurveyService) {
    // this.surveyService.savedSurvey.subscribe(data => {
    //   if (data) {
    //     this.bool = true;
    //   }
    // });
  }

  canLoad() {
    if (this.bool === true) {
      return true;
    }
    this.router.navigateByUrl('app/admin/create');
    return false;
  }
}
