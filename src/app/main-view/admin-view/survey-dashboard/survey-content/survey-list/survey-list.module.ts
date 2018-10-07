import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { RouterModule, Routes } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { MaterialsModule } from '../../../../../materials/materials.module';
import { ConfirmDialogComponent } from '../../../../../shared/confirm-dialog/confirm-dialog.component';
import { SharedModule } from '../../../../../shared/shared.module';
import { SurveyListComponent } from './survey-list.component';
import { SurveyTileComponent } from './survey-tile/survey-tile.component';

export const routes: Routes = [{ path: '', component: SurveyListComponent }];

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    FontAwesomeModule,
    MaterialsModule,
    MatProgressSpinnerModule,
    SharedModule,
    RouterModule.forChild(routes)
  ],
  entryComponents: [ConfirmDialogComponent],
  declarations: [SurveyListComponent, SurveyTileComponent],
  exports: [SurveyListComponent, SurveyTileComponent]
})
export class SurveyListModule {}
