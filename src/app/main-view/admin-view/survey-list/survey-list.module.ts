import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
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
