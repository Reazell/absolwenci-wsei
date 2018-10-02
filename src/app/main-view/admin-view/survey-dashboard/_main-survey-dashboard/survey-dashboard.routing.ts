import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SurveyDashboardComponent } from './survey-dashboard.component';

const surveyDashboardRoutes: Routes = [
  {
    path: '',
    component: SurveyDashboardComponent,
    children: [
      // {
      //   path: 'create',
      //   loadChildren:
      //     './survey-creator/survey-creator.module#SurveyCreatorModule',
      //   canLoad: [AuthGuard]
      // },
      // {
      //   path: 'viewform',
      //   loadChildren:
      //     './survey-viewform/survey-viewform.module#SurveyViewformModule',
      //   canLoad: [AuthGuard]
      // }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(surveyDashboardRoutes)],
  exports: [RouterModule]
})
export class SurveyDashboardRoutingModule {}
