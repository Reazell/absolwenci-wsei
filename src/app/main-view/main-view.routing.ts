import { MainViewComponent } from './main-view.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

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
        loadChildren: './student-view/student-view.module#StudentViewModule'
      },
      {
        path: 'graduate',
        loadChildren: './graduate-view/graduate-view.module#GraduateViewModule'
      },
      {
        path: 'employer',
        loadChildren: './employer-view/employer-view.module#EmployerViewModule'
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(mainRoutes)],
  exports: [RouterModule]
})
export class MainViewRoutingModule {}
