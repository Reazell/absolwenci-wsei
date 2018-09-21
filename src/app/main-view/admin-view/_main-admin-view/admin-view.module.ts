import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { MatSidenavModule } from '@angular/material';
import { MaterialsModule } from '../../../materials/materials.module';
import { RouteGuard } from '../../../others/route.auth';
import { SurveyGuard } from '../../../others/survey.auth';
import { SurveyService } from '../survey-container/services/survey.services';
import { GroupListModule } from '../survey-dashboard/group-list/group-list.module';
import { ManageBarModule } from '../survey-dashboard/manage-bar/manage-bar.module';
import { SurveyListModule } from '../survey-dashboard/survey-list/survey-list.module';
import { SurveySearchModule } from '../survey-dashboard/survey-search/survey-search.module';
import { AdminViewComponent } from './admin-view.component';
import { AdminViewRoutingModule } from './admin-view.routing';

@NgModule({
  imports: [
    CommonModule,
    MaterialsModule,
    ReactiveFormsModule,
    SurveySearchModule,
    ManageBarModule,
    GroupListModule,
    SurveyListModule,
    AdminViewRoutingModule,
    MatSidenavModule
  ],
  declarations: [AdminViewComponent],
  providers: [SurveyGuard, SurveyService, RouteGuard]
})
export class AdminViewModule {}
