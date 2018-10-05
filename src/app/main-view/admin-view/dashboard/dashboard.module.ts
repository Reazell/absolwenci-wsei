import { DashboardSidebarModule } from './dashboard-sidebar/dashboard-sidebar.module';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MatSidenavModule } from '@angular/material';
import { MaterialsModule } from '../../../materials/materials.module';
import { SharedModule } from '../../../shared/shared.module';
import { DashboardComponent } from './dashboard.component';
import { DashboardRoutingModule } from './dashboard.routing';
import { ManageBarModule } from './manage-bar/manage-bar.module';
import { SurveyListModule } from './survey-list/survey-list.module';
import { SurveySearchModule } from './survey-search/survey-search.module';

@NgModule({
  imports: [
    CommonModule,
    DashboardRoutingModule,
    MaterialsModule,
    SurveySearchModule,
    ManageBarModule,
    SurveyListModule,
    MatSidenavModule,
    SharedModule,
    DashboardSidebarModule
  ],
  declarations: [DashboardComponent],
  exports: [DashboardComponent]
})
export class DashboardModule {}
