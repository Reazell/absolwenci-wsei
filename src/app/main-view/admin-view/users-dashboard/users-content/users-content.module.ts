import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { RouterModule, Routes } from '@angular/router';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
// import { MatNativeDateModule } from '../../../../../../node_modules/@angular/material';
import { ConfirmDialogComponent } from '../../../../shared/confirm-dialog/confirm-dialog.component';
import { DashboardBarModule } from '../../../../shared/dashboard/dashboard-bar/dashboard-bar.module';
import { DashboardListModule } from '../../../../shared/dashboard/dashboard-list/dashboard-list.module';
import { MaterialsModule } from './../../../../materials/materials.module';
import { AddUserDialogComponent } from './add-user-dialog/add-user-dialog.component';
import { UsersContentComponent } from './users-content.component';
import { UsersTileComponent } from './users-tile/users-tile.component';

export const routes: Routes = [{ path: '', component: UsersContentComponent }];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    DashboardBarModule,
    DashboardListModule,
    MaterialsModule,
    ReactiveFormsModule,
    ProgressSpinnerModule,
    MatDatepickerModule,
    // MatNativeDateModule
  ],
  entryComponents: [ConfirmDialogComponent, AddUserDialogComponent],
  declarations: [
    UsersContentComponent,
    UsersTileComponent,
    AddUserDialogComponent
  ]
})
export class UsersContentModule {}
