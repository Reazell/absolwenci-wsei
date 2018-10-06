import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '../../../auth/other/guard.auth';
import { AdminViewComponent } from './admin-view.component';

const adminRoutes: Routes = [
  {
    path: '',
    component: AdminViewComponent,
    children: [
      {
        path: '',
        loadChildren: './../admin-dashboard/admin-dashboard.module#AdminDashboardModule',
        canLoad: [AuthGuard]
      },
      {
        path: 'd',
        loadChildren: './../dashboard/dashboard.module#DashboardModule',
        canLoad: [AuthGuard]
      },
      {
        path: 'survey',
        loadChildren:
          './../survey-container/_main-survey-container/survey-container.module#SurveyContainerModule',
        canLoad: [AuthGuard]
      }
    ]
  }
  //   path: 'list',
  //   loadChildren:
  //     './draggable/sortable-list/sortable-list.module#SortableListModule',
  //   canLoad: [AuthGuard]
  // }
];

@NgModule({
  imports: [RouterModule.forChild(adminRoutes)],
  exports: [RouterModule]
})
export class AdminViewRoutingModule {}
