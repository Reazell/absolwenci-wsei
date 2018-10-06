import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { MaterialsModule } from '../../../../materials/materials.module';
import { SurveyBarComponent } from './survey-bar.component';

export const routes: Routes = [{ path: '', component: SurveyBarComponent }];

@NgModule({
  imports: [
    CommonModule,
    FontAwesomeModule,
    MaterialsModule,
    RouterModule.forChild(routes)
  ],
  declarations: [SurveyBarComponent],
  exports: [ SurveyBarComponent]
})
export class SurveyBarModule {}
