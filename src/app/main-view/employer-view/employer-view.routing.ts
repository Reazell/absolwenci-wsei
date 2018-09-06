import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { EmployerViewComponent } from './employer-view.component';

const employerRoutes: Routes = [
  {
    path: '',
    component: EmployerViewComponent
  }
];


@NgModule({
  imports: [RouterModule.forChild(employerRoutes)],
  exports: [RouterModule]
})
export class EmployerViewRoutingModule { }
