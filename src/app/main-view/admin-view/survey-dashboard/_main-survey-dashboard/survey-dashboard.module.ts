import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { MatSidenavModule } from '@angular/material';
import { MaterialsModule } from '../../../../materials/materials.module';
import { SharedModule } from '../../../../shared/shared.module';
import { GroupListModule } from '../group-list/group-list.module';
import { ManageBarModule } from '../manage-bar/manage-bar.module';
import { SurveyListModule } from '../survey-list/survey-list.module';
import { SurveySearchModule } from '../survey-search/survey-search.module';
import { SharedService } from './../../../../services/shared.service';
import { SurveyDashboardComponent } from './survey-dashboard.component';
import { SurveyDashboardRoutingModule } from './survey-dashboard.routing';

@NgModule({
  imports: [
    CommonModule,
    MaterialsModule,
    ReactiveFormsModule,
    SurveySearchModule,
    ManageBarModule,
    GroupListModule,
    SurveyListModule,
    MatSidenavModule,
    SurveyDashboardRoutingModule,
    SharedModule
  ],
  declarations: [SurveyDashboardComponent]
})
export class SurveyDashboardModule {}
