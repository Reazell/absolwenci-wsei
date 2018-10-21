import {
  Component,
  ContentChild,
  Input,
  OnDestroy,
  OnInit,
  TemplateRef
} from '@angular/core';
import { MatDialog } from '@angular/material';
import { Subscription } from 'rxjs/Subscription';
// import { Survey } from '../../../main-view/admin-view/survey-container/models/survey.model';
import { SurveyService } from '../../../main-view/admin-view/survey-container/services/survey.services';

@Component({
  selector: 'app-dashboard-list',
  templateUrl: './dashboard-list.component.html',
  styleUrls: ['./dashboard-list.component.scss']
})
export class DashboardListComponent implements OnInit, OnDestroy {
  @Input()
  itemArr;
  @Input()
  emptyListInfo: string;
  @ContentChild(TemplateRef)
  parentTemplate;
  loading = false;
  // // subs
  isLoadingSub: Subscription = new Subscription();

  constructor(private surveyService: SurveyService, public dialog: MatDialog) {}

  ngOnInit(): void {
    this.isLoadingFromOutside();
  }

  isLoadingFromOutside(): void {
    this.isLoadingSub = this.surveyService.openingCreatorLoader.subscribe(
      data => {
        this.loading = data;
      }
    );
  }
  // saveSurveysFromApi(): void {
  //   this.surveyService.saveSurveysFromApi();
  // }
  // filterSurveyList(): void {
  //   this.surveyService.filterSurveyListInput.subscribe(data => {
  //     // this.surveyArr.filter(filtered => console.log(filtered));
  //     this.surveyArr.filter(sth => {
  //       console.log(data);
  //       console.log(sth);
  //     });
  //   });
  // }
  ngOnDestroy(): void {
    this.loading = false;
    this.isLoadingSub.unsubscribe();
  }
}
