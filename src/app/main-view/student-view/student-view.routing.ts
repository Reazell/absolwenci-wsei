import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { StudentViewComponent } from './student-view.component';

const studentRoutes: Routes = [
  {
    path: '',
    component: StudentViewComponent
    // children: [
    //   {
    //     path: '',
    //     loadChildren: './pooling-space/pooling-space.module#PoolingSpaceModule'
    //   }
    // ]
  }
];


@NgModule({
  imports: [RouterModule.forChild(studentRoutes)],
  exports: [RouterModule]
})
export class StudentViewRoutingModule {}
