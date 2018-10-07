import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { SharedModule } from './../../../shared/shared.module';
import { SurveyDashboardComponent } from './survey-dashboard.component';

@NgModule({
  imports: [
    CommonModule,
    SharedModule
  ],
  declarations: [SurveyDashboardComponent]
})
export class SurveyDashboardModule { }
