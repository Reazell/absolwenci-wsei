import { MaterialsModule } from './../../../materials/materials.module';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SurveyViewformComponent } from './survey-viewform.component';
import { SurveyViewformRoutingModule } from './survey-viewform.routing';
import {
  MatRadioModule,
  MatCheckboxModule
} from '../../../../../node_modules/@angular/material';

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
  declarations: [SurveyViewformComponent],
  exports: [SurveyViewformComponent]
})
export class SurveyViewformModule {}
