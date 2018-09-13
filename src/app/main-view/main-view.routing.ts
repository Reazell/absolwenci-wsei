import { MainViewComponent } from './main-view.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../auth/other/guard.auth';

const mainRoutes: Routes = [
  {
    path: '',
    component: MainViewComponent,
    children: [
      {
        path: 'admin',
        loadChildren: './admin-view/admin-view.module#AdminViewModule'
      },
      {
        path: 'student',
        loadChildren: './student-view/student-view.module#StudentViewModule',
        canLoad: [AuthGuard]
      },
      {
        path: 'graduate',
        loadChildren: './graduate-view/graduate-view.module#GraduateViewModule',
        canLoad: [AuthGuard]
      },
      {
        path: 'employer',
        loadChildren: './employer-view/employer-view.module#EmployerViewModule',
        canLoad: [AuthGuard]
      },
      {
        path: 'settings',
        loadChildren: './settings/settings.module#SettingsModule',
        canLoad: [AuthGuard]
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(mainRoutes)],
  exports: [RouterModule]
})
export class MainViewRoutingModule {}
