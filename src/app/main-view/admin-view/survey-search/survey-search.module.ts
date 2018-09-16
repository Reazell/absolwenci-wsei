import { MatToolbarModule } from '@angular/material/toolbar';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SurveySearchComponent } from './survey-search.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

@NgModule({
  imports: [CommonModule, MatToolbarModule, FontAwesomeModule],
  declarations: [SurveySearchComponent],
  exports: [SurveySearchComponent]
})
export class SurveySearchModule {}
