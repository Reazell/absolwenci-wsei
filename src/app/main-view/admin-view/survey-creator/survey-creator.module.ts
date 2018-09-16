import { DraggableModule } from '../draggable/draggable.module';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialsModule } from '../../../materials/materials.module';
import { MatRadioModule } from '@angular/material';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { SurveyCreatorRoutingModule } from './survey-creator.routing';
import { SurveyCreatorComponent } from './survey-creator.component';
import { SendSurveyDialogComponent } from './send-survey-dialog/send-survey-dialog.component';

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
    DraggableModule
  ],
  declarations: [SurveyCreatorComponent, SendSurveyDialogComponent],
  entryComponents: [SendSurveyDialogComponent]
})
export class SurveyCreatorModule {}
