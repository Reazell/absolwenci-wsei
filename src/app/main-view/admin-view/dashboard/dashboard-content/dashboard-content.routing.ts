import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardContentComponent } from './dashboard-content.component';

const routes: Routes = [
  {
    path: '',
    component: DashboardContentComponent,
    // children: [
    //   {
    //     path: '',
    //     loadChildren:
    //       './../../survey-dashboard/survey-content/survey-content.module#SurveyContentModule'
    //   }
    // ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DashboardContentRoutingModule {}
