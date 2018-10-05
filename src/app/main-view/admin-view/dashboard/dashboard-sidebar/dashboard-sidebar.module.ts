import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { DashboardSidebarComponent } from './dashboard-sidebar.component';
import { DashboardSidebarRoutingModule } from './dashboard-sidebar.routing';

@NgModule({
  imports: [
    CommonModule,
    DashboardSidebarRoutingModule
  ],
  declarations: [DashboardSidebarComponent]
})
export class DashboardSidebarModule {}
