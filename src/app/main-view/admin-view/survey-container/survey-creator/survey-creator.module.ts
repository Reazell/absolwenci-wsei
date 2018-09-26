import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {
  MatCheckboxModule,
  MatRadioModule,
  MatSlideToggleModule
} from '@angular/material';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { SortablejsModule } from '../../../../../../node_modules/angular-sortablejs/dist';
import { MaterialsModule } from '../../../../materials/materials.module';
import { DraggableModule } from '../directives/draggable.module';
import { MoveQuestionDialogComponent } from './move-question-dialog/move-question-dialog.component';
import { SendSurveyDialogComponent } from './send-survey-dialog/send-survey-dialog.component';
import { ButtonSingleControlComponent } from './survey-creator-component/button-single-control/button-single-control.component';
import { SurveyCreatorComponent } from './survey-creator.component';
import { SurveyCreatorRoutingModule } from './survey-creator.routing';

@NgModule({
  imports: [
    CommonModule,
    SurveyCreatorRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    MaterialsModule,
    MatRadioModule,
    MatCheckboxModule,
    FontAwesomeModule,
    DraggableModule,
    ProgressSpinnerModule,
    MatSlideToggleModule,
    SortablejsModule
  ],
  declarations: [
    SurveyCreatorComponent,
    SendSurveyDialogComponent,
    ButtonSingleControlComponent,
    MoveQuestionDialogComponent
  ],
  entryComponents: [SendSurveyDialogComponent, MoveQuestionDialogComponent]
})
export class SurveyCreatorModule {}
