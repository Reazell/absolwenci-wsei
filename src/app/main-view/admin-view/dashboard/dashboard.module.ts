import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MatSidenavModule } from '@angular/material';
import { SharedModule } from '../../../shared/shared.module';
import { DashboardContentModule } from './dashboard-content/dashboard-content.module';
import { DashboardSidenavModule } from './dashboard-sidenav/dashboard-sidenav.module';
import { DashboardComponent } from './dashboard.component';
import { DashboardRoutingModule } from './dashboard.routing';
// import { GroupListModule } from './group-list/group-list.module';
// import { SurveyBarModule } from './survey-bar/survey-bar.module';
import { SurveyListModule } from './survey-list/survey-list.module';
import { SurveySearchModule } from './survey-search/survey-search.module';

@NgModule({
  imports: [
    CommonModule,
    DashboardRoutingModule,
    SurveySearchModule,
    SurveyListModule,
    MatSidenavModule,
    SharedModule,
    DashboardSidenavModule,
    DashboardContentModule
    // SurveyBarModule,
    // GroupListModule
  ],
  declarations: [DashboardComponent],
  exports: [DashboardComponent]
})
export class DashboardModule {}
