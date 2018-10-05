import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouteGuard } from '../../../others/route.auth';
import { SurveyGuard } from '../../../others/survey.auth';
import { SurveyService } from '../survey-container/services/survey.services';
import { AdminViewComponent } from './admin-view.component';
import { AdminViewRoutingModule } from './admin-view.routing';

@NgModule({
  imports: [
    CommonModule,
    AdminViewRoutingModule,
  ],
  declarations: [AdminViewComponent],
  providers: [SurveyGuard, SurveyService, RouteGuard]
})
export class AdminViewModule {}
