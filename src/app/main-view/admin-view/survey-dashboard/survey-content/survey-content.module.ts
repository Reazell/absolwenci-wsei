import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { SurveyBarModule } from './survey-bar/survey-bar.module';
import { SurveyContentComponent } from './survey-content.component';
import { SurveyListModule } from './survey-list/survey-list.module';

@NgModule({
  imports: [CommonModule, SurveyBarModule, SurveyListModule],
  declarations: [SurveyContentComponent]
})
export class SurveyContentModule {}
