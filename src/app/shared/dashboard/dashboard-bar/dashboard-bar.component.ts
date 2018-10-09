import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { SurveyService } from '../../../main-view/admin-view/survey-container/services/survey.services';

@Component({
  selector: 'app-dashboard-bar',
  templateUrl: './dashboard-bar.component.html',
  styleUrls: ['./dashboard-bar.component.scss']
})
export class DashboardBarComponent implements OnInit {
  @Input()
  groupTitle;
  @Input()
  buttonDets;
  @Output()
  buttonClick: EventEmitter<boolean> = new EventEmitter<boolean>();

  constructor(private surveyService: SurveyService) {}

  ngOnInit() {}

  // redirectToNew(): void {
  //   this.surveyService.isCreatorLoading(true);
  //   const obj = {
  //     title: '',
  //     questions: []
  //   };
  //   this.surveyService.createSurvey(obj).subscribe(
  //     data => {
  //       console.log(data);
  //       const string: string = '/app/admin/survey/create/' + data;
  //       this.router.navigateByUrl(string);
  //       this.surveyService.isCreatorLoading(false);
  //     },
  //     error => {
  //       console.log(error);
  //     }
  //   );
  // }
  onButtonClick() {
    this.surveyService.isCreatorLoading(true);
    this.buttonClick.emit(true);
  }

  searchSurveyList(searchString: string): void {
    this.surveyService.filterSurveyList(searchString);
  }
}
