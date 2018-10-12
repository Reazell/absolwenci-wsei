import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '../../../auth/other/guard.auth';
import { SurveyCreatorResolver } from './resolvers/survey-creator.resolver';
import { SurveyContainerComponent } from './survey-container.component';

const surveyContainerRoutes: Routes = [
  {
    path: '',
    component: SurveyContainerComponent,
    children: [
      {
        path: 'create/:id',
        loadChildren:
          './survey-creator/survey-creator.module#SurveyCreatorModule',
        canLoad: [AuthGuard],
        resolve: {
          cres: SurveyCreatorResolver
        }
      },
      {
        path: 'viewform/:id/:hash',
        loadChildren:
          './survey-viewform/survey-viewform.module#SurveyViewformModule'
        // canLoad: [SurveyGuard],
        // canLoad: [RouteGuard]
      },
      {
        path: 'result/:id',
        loadChildren:
          './survey-result/survey-result.module#SurveyResultModule',
        canLoad: [AuthGuard]
      },
      {
        path: 'response',
        loadChildren:
          './survey-viewform/survey-completed/survey-completed.module#SurveyCompletedModule'
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(surveyContainerRoutes)],
  exports: [RouterModule]
})
export class SurveyContainerRoutingModule {}
