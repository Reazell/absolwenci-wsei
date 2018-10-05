import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardSidebarComponent } from './dashboard-sidebar.component';

const routes: Routes = [
  {
    path: '',
    component: DashboardSidebarComponent,
    children: [
      {
        path: '',
        loadChildren: './group-list/group-list.module#GroupListModule'

      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DashboardSidebarRoutingModule {}
