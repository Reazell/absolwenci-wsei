import { MaterialsModule } from '../../../materials/materials.module';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SurveyViewformComponent } from './survey-viewform.component';
import { SurveyViewformRoutingModule } from './survey-viewform.routing';
import {
  MatRadioModule,
  MatCheckboxModule
} from '@angular/material';
import { SurveySentComponent } from './survey-sent/survey-sent.component';

@NgModule({
  imports: [
    CommonModule,
    SurveyViewformRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    MaterialsModule,
    MatRadioModule,
    MatCheckboxModule,
    FontAwesomeModule
  ],
  declarations: [SurveyViewformComponent, SurveySentComponent],
  exports: [SurveyViewformComponent]
})
export class SurveyViewformModule {}
