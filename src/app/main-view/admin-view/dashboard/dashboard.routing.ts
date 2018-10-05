import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard.component';
// import { DashboardSidebarComponent } from './dashboard-sidebar/dashboard-sidebar.component';

const dashboardRoutes: Routes = [
  {
    path: '',
    component: DashboardComponent,
    // children: [
    //   {
    //     path: '',
    //     loadChildren:
    //       './dashboard-sidebar/dashboard-sidebar.module#DashboardSidebarModule',
    //     // component: DashboardSidebarComponent
    //   }
    // ]
    children: [
      {
        path: '',
        loadChildren:
          './dashboard-sidebar/dashboard-sidebar.module#DashboardSidebarModule'
        // component: DashboardSidebarComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(dashboardRoutes)],
  exports: [RouterModule]
})
export class DashboardRoutingModule {}
