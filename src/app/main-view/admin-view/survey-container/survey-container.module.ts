import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { SurveyCreatorResolver } from './resolvers/survey-creator.resolver';
import { SurveyResultResolver } from './resolvers/survey-result.resolver';
import { SurveyViewformResolver } from './resolvers/survey-viewform.resolver';
import { SurveyContainerComponent } from './survey-container.component';
import { SurveyContainerRoutingModule } from './survey-container.routing';

@NgModule({
  imports: [CommonModule, SurveyContainerRoutingModule],
  declarations: [SurveyContainerComponent],
  providers: [
    SurveyCreatorResolver,
    SurveyViewformResolver,
    SurveyResultResolver
  ]
})
export class SurveyContainerModule {}
