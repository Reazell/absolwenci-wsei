import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { AdminDashboardComponent } from './admin-dashboard.component';
import { AdminDashboardRoutingModule } from './admin-dashboard.routing';

@NgModule({
  imports: [
    CommonModule,
    AdminDashboardRoutingModule
  ],
  declarations: [AdminDashboardComponent]
})
export class AdminDashboardModule { }
