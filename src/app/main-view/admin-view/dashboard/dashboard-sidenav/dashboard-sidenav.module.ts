import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { DashboardSidenavComponent } from './dashboard-sidenav.component';

@NgModule({
  imports: [CommonModule],
  declarations: [DashboardSidenavComponent],
  exports: [DashboardSidenavComponent]
})
export class DashboardSidenavModule {}
