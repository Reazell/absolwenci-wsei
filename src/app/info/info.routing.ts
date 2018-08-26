import { InfoComponent } from './info.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const infoRoutes: Routes = [
  {
    path: '',
    component: InfoComponent,
    children: [
      {
        path: 'student',
        loadChildren: './student/student.module#StudentModule'
      },
      {
        path: 'graduate',
        loadChildren: './graduate/graduate.module#GraduateModule'
      },
      {
        path: 'employer',
        loadChildren: './employer/employer.module#EmployerModule'
      },
      {
        path: 'contact',
        loadChildren: './contact/contact.module#ContactModule'
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(infoRoutes)],
  exports: [RouterModule]
})
export class InfoRoutingModule {}
