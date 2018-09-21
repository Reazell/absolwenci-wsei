import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { SurveyListComponent } from './survey-list.component';
import { SurveyTileComponent } from './survey-tile/survey-tile.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    FontAwesomeModule
  ],
  declarations: [SurveyListComponent, SurveyTileComponent],
  exports: [SurveyListComponent, SurveyTileComponent]
})
export class SurveyListModule { }
