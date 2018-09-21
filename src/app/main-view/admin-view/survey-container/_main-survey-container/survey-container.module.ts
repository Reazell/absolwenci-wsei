import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { SurveyContainerComponent } from './survey-container.component';
import { SurveyContainerRoutingModule } from './survey-container.routing';

@NgModule({
  imports: [CommonModule, SurveyContainerRoutingModule],
  declarations: [SurveyContainerComponent]
})
export class SurveyContainerModule {}
