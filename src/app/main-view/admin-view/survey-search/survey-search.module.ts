import { MatToolbarModule } from '@angular/material/toolbar';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SurveySearchComponent } from './survey-search.component';

@NgModule({
  imports: [
    CommonModule,
    MatToolbarModule
  ],
  declarations: [SurveySearchComponent],
  exports: [SurveySearchComponent]
})
export class SurveySearchModule { }
