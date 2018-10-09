import {
  Component,
  ContentChild,
  EventEmitter,
  Input,
  OnDestroy,
  OnInit,
  Output,
  TemplateRef
} from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { Subscription } from 'rxjs/Subscription';
// import { Survey } from '../../../main-view/admin-view/survey-container/models/survey.model';
import { SurveyService } from '../../../main-view/admin-view/survey-container/services/survey.services';
import { ConfirmDialogComponent } from '../../confirm-dialog/confirm-dialog.component';

@Component({
  selector: 'app-dashboard-list',
  templateUrl: './dashboard-list.component.html',
  styleUrls: ['./dashboard-list.component.scss']
})
export class DashboardListComponent implements OnInit, OnDestroy {
  @Input()
  itemArr;
  @Output()
  resultButton: EventEmitter<any> = new EventEmitter<any>();
  @Output()
  dialogButton: EventEmitter<number> = new EventEmitter<number>();
  @ContentChild(TemplateRef)
  parentTemplate;
  loading = false;
  // // subs
  // getAllSurveysSub: Subscription = new Subscription();
  isLoadingSub: Subscription = new Subscription();
  // surveyArr: Survey[];
  constructor(
    private surveyService: SurveyService,
    private router: Router,
    public dialog: MatDialog
  ) {}

  ngOnInit(): void {
    // this.getAllSurveys();
    this.isLoadingFromOutside();
    // this.filterSurveyList();
  }
  resultButtonClick(item: any): void {
    this.resultButton.emit(item);
  }
  dialogButtonClick(id: number) {
    console.log(id);

    this.dialogButton.emit(id);
  }

  isLoadingFromOutside(): void {
    this.isLoadingSub = this.surveyService.openingCreatorLoader.subscribe(
      data => {
        console.log(data);
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
  // getAllSurveys(): void {
  //   this.saveSurveysFromApi();
  //   this.getAllSurveysSub = this.surveyService.savedSurveys.subscribe(
  //     data => {
  //       if (data) {
  //         this.surveyArr = data;
  //       }
  //     },
  //     error => {
  //       console.log(error);
  //     }
  //   );
  // }
  // // subToObs() {
  // //   this.updateToApi$
  // //     .pipe(
  // //       debounceTime(300),
  // //       switchMap(() => this.updateSurvey())
  // //     )
  // //     .subscribe(res => {
  // //       console.log(res);
  // //     });
  // // }
  // openCreator(survey): void {
  //   this.loading = true;
  //   this.router.navigateByUrl('/app/admin/survey/create/' + survey.id);
  // }
  // openResult(survey): void {
  //   this.loading = true;
  //   this.router.navigateByUrl('/app/admin/survey/result/' + survey.id);
  // }

  // deleteSurvey(id: number): void {
  //   this.surveyService.deleteSurvey(id).subscribe(
  //     () => {
  //       this.saveSurveysFromApi();
  //     },
  //     error => {
  //       console.log(error);
  //     }
  //   );
  // }
  // openConfimDeleteDialog(id: number): void {
  //   this.openSurveyDialog().subscribe((res: boolean) => {
  //     if (res === true) {
  //       this.deleteSurvey(id);
  //     }
  //   });
  // }
  // openSurveyDialog(): Observable<boolean> {
  //   const dialogRef: MatDialogRef<ConfirmDialogComponent> = this.dialog.open(
  //     ConfirmDialogComponent
  //   );
  //   return dialogRef.afterClosed();
  // }
  ngOnDestroy(): void {
    this.loading = false;
    this.isLoadingSub.unsubscribe();
  }
}
