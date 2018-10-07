import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { GroupListModule } from './group-list/group-list.module';
import { SurveySearchModule } from './survey-search/survey-search.module';
import { SurveySidenavComponent } from './survey-sidenav.component';

@NgModule({
  imports: [
    CommonModule,
    GroupListModule,
    SurveySearchModule
  ],
  declarations: [SurveySidenavComponent]
})
export class SurveySidenavModule { }
