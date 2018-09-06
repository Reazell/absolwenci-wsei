import { ReactiveFormsModule } from '@angular/forms';
import { SurveyService } from '../../services/survey.services';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SurveySpaceRoutingModule } from './Survey-space.routing';
import { MatFormFieldModule } from '@angular/material';
import { SurveyWriteComponent } from './survey-write/survey-write.component';
import { SurveyDefaultComponent } from './survey-default/survey-default.component';
import { SurveySpaceComponent } from './survey-space.component';
import { SurveyViewComponent } from './survey-view/survey-view.component';

@NgModule({
  imports: [
    CommonModule,
    SurveySpaceRoutingModule,
    ReactiveFormsModule,
    MatFormFieldModule
  ],
  declarations: [
    SurveySpaceComponent,
    SurveyViewComponent,
    SurveyDefaultComponent,
    SurveyWriteComponent
  ],
  providers: [SurveyService]
})
export class SurveySpaceModule {}
