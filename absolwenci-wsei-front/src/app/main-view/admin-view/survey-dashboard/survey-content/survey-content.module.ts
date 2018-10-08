import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardBarModule } from './../../../../shared/dashboard/dashboard-bar/dashboard-bar.module';
import { SurveyContentComponent } from './survey-content.component';
import { SurveyListModule } from './survey-list/survey-list.module';

export const routes: Routes = [{ path: '', component: SurveyContentComponent }];

@NgModule({
  imports: [
    CommonModule,
    DashboardBarModule,
    SurveyListModule,
    RouterModule.forChild(routes)
  ],
  declarations: [SurveyContentComponent]
})
export class SurveyContentModule {}
