import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { DashboardSidenavComponent } from './dashboard-sidenav.component';
import { DashboardSidenavRoutingModule } from './dashboard-sidenav.routing';

@NgModule({
  imports: [CommonModule, DashboardSidenavRoutingModule],
  declarations: [DashboardSidenavComponent]
  // exports: [DashboardSidenavComponent]
})
export class DashboardSidenavModule {}
