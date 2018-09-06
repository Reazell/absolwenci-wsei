import { GraduateViewComponent } from './graduate-view.component';
import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

const graduateRoutes: Routes = [
  {
    path: '',
    component: GraduateViewComponent
  }
];


@NgModule({
  imports: [RouterModule.forChild(graduateRoutes)],
  exports: [RouterModule]
})
export class GraduateViewRoutingModule { }
