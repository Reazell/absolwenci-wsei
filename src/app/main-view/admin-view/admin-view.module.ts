import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouteGuard } from '../../others/route.auth';
import { SurveyGuard } from '../../others/survey.auth';
import { AdminViewComponent } from './admin-view.component';
import { AdminViewRoutingModule } from './admin-view.routing';
import { SurveyService } from './survey-container/services/survey.services';
import { UserService } from './survey-container/services/user.services';

@NgModule({
  imports: [CommonModule, AdminViewRoutingModule],
  declarations: [AdminViewComponent],
  providers: [SurveyGuard, SurveyService, RouteGuard, UserService]
})
export class AdminViewModule {}
