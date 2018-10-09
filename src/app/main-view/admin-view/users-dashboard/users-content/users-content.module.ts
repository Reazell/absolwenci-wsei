import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardBarModule } from '../../../../shared/dashboard/dashboard-bar/dashboard-bar.module';
import { ConfirmDialogComponent } from './../../../../shared/confirm-dialog/confirm-dialog.component';
import { DashboardListModule } from './../../../../shared/dashboard/dashboard-list/dashboard-list.module';
import { UsersContentComponent } from './users-content.component';
import { UsersTileComponent } from './users-tile/users-tile.component';

export const routes: Routes = [{ path: '', component: UsersContentComponent }];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    DashboardBarModule,
    DashboardListModule
  ],
  entryComponents: [ConfirmDialogComponent],
  declarations: [UsersContentComponent, UsersTileComponent]
})
export class UsersContentModule {}
