import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatRadioModule } from '@angular/material';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { SurveyCreatorRoutingModule } from './survey-creator.routing';
import { SurveyCreatorComponent } from './survey-creator.component';
import { SendSurveyDialogComponent } from './send-survey-dialog/send-survey-dialog.component';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { ButtonSingleControlComponent } from './survey-creator-component/button-single-control/button-single-control.component';
import { MaterialsModule } from '../../../../materials/materials.module';

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
    // DraggableModule,
    ProgressSpinnerModule
  ],
  declarations: [
    SurveyCreatorComponent,
    SendSurveyDialogComponent,
    ButtonSingleControlComponent
  ],
  entryComponents: [SendSurveyDialogComponent]
})
export class SurveyCreatorModule {}
