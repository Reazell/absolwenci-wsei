import { SurveyService } from '../../services/survey.services';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialsModule } from '../../../materials/materials.module';
import { MatRadioModule } from '@angular/material';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { SurveyCreatorRoutingModule } from './survey-creator.routing';
import { SurveyCreatorComponent } from './survey-creator.component';

@NgModule({
  imports: [
    CommonModule,
    SurveyCreatorRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    MaterialsModule,
    MatRadioModule,
    MatCheckboxModule,
    FontAwesomeModule
  ],
  declarations: [SurveyCreatorComponent]
})
export class SurveyCreatorModule {}
