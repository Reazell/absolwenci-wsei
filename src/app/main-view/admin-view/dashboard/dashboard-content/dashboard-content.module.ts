import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { SharedModule } from '../../../../shared/shared.module';
import { DashboardContentComponent } from './dashboard-content.component';
import { DashboardContentRoutingModule } from './dashboard-content.routing';

@NgModule({
  imports: [CommonModule, SharedModule, DashboardContentRoutingModule],
  declarations: [DashboardContentComponent],
  exports: [DashboardContentComponent]
})
export class DashboardContentModule {}
