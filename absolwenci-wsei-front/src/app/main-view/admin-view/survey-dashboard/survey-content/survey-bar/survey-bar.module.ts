import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { MaterialsModule } from '../../../../../materials/materials.module';
import { SurveyBarComponent } from './survey-bar.component';

@NgModule({
  imports: [CommonModule, FontAwesomeModule, MaterialsModule],
  declarations: [SurveyBarComponent],
  exports: [SurveyBarComponent]
})
export class SurveyBarModule {}
