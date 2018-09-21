import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '../../../../auth/other/guard.auth';
import { SurveyContainerComponent } from './survey-container.component';

const surveyContainerRoutes: Routes = [
  {
    path: '',
    component: SurveyContainerComponent,
    children: [
      {
        path: 'create',
        loadChildren:
          './../survey-creator/survey-creator.module#SurveyCreatorModule',
        canLoad: [AuthGuard]
      },
      {
        path: 'viewform',
        loadChildren:
          './../survey-viewform/survey-viewform.module#SurveyViewformModule',
        canLoad: [AuthGuard]
      },
      {
        path: 'create/:id',
        loadChildren: './../survey-creator/survey-creator.module#SurveyCreatorModule',
        canLoad: [AuthGuard]
      },
      {
        path: 'viewform/:id',
        loadChildren:
          './../survey-viewform/survey-viewform.module#SurveyViewformModule'
        // canLoad: [SurveyGuard],
        // canLoad: [RouteGuard]
      },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(surveyContainerRoutes)],
  exports: [RouterModule]
})
export class SurveyContainerRoutingModule {}
