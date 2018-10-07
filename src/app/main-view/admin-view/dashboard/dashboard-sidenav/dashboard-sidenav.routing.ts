import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardSidenavComponent } from './dashboard-sidenav.component';

const routes: Routes = [
  {
    path: '',
    component: DashboardSidenavComponent,
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
export class DashboardSidenavRoutingModule {}
