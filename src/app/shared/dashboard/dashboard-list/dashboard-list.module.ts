import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { RouterModule } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { MaterialsModule } from '../../../materials/materials.module';
import { ConfirmDialogModule } from '../../confirm-dialog/confirm-dialog.module';
import { DashboardListComponent } from './dashboard-list.component';
import { DashboardTileComponent } from './dashboard-tile/dashboard-tile.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    FontAwesomeModule,
    MaterialsModule,
    MatProgressSpinnerModule,
    ConfirmDialogModule,
  ],
  declarations: [DashboardListComponent, DashboardTileComponent],
  exports: [DashboardListComponent, DashboardTileComponent]
})
export class DashboardListModule {}
