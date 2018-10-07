import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MatSidenavModule } from '@angular/material';
import { SharedModule } from '../../../shared/shared.module';
import { DashboardComponent } from './dashboard.component';
import { DashboardRoutingModule } from './dashboard.routing';

@NgModule({
  imports: [
    CommonModule,
    DashboardRoutingModule,
    MatSidenavModule,
    SharedModule
  ],
  declarations: [DashboardComponent],
  exports: [DashboardComponent]
})
export class DashboardModule {}
