import { CommonModule } from '@angular/common';
import { Component, NgModule } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { RouterModule, Routes } from '@angular/router';
import { DashboardListComponent } from './../../../../../shared/dashboard/dashboard-list/dashboard-list.component';
import { LoadingOverlayModule } from './../../../../../shared/loading-overlay/loading-overlay.module';
import { AdminContentComponent } from './admin-content.component';
export const routes: Routes = [{ path: '', component: AdminContentComponent }];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    MatCardModule,
    // LoadingOverlayModule
  ],
  declarations: [
    AdminContentComponent,
    // DashboardListComponent
  ]
})
export class AdminContentModule { }
