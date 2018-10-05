import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { SurveyCreatorResolver } from '../resolvers/survey-creator.resolver';
import { SurveyContainerComponent } from './survey-container.component';
import { SurveyContainerRoutingModule } from './survey-container.routing';

@NgModule({
  imports: [CommonModule, SurveyContainerRoutingModule],
  declarations: [SurveyContainerComponent],
  providers: [SurveyCreatorResolver]
})
export class SurveyContainerModule {}
