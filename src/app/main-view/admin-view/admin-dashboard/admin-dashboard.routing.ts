import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminDashboardComponent } from './admin-dashboard.component';

const adminDashboardRoutes: Routes = [
  {
    path: '',
    component: AdminDashboardComponent,
    children: []
  }
];

@NgModule({
  imports: [RouterModule.forChild(adminDashboardRoutes)],
  exports: [RouterModule]
})
export class AdminDashboardRoutingModule {}
