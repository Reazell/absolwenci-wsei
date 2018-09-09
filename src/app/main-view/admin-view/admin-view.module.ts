import { SurveyGuard } from '../../others/survey.auth';
import { SurveyService } from '../services/survey.services';
import { SurveyListModule } from './Survey-list/Survey-list.module';
import { GroupListModule } from './group-list/group-list.module';
import { MaterialsModule } from '../../materials/materials.module';
import { AdminViewRoutingModule } from './admin-view.routing';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminViewComponent } from './admin-view.component';
import { MatSidenavModule } from '@angular/material';
import { ReactiveFormsModule } from '@angular/forms';
import { SurveySearchModule } from './Survey-search/Survey-search.module';
import { ManageBarModule } from './manage-bar/manage-bar.module';
import { RouteGuard } from '../../others/route.auth';

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
