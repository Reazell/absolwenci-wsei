import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '../../auth/other/guard.auth';
import { SurveyCreatorResolver } from '../../main-view/admin-view/survey-container/resolvers/survey-creator.resolver';
import { SurveyResultResolver } from '../../main-view/admin-view/survey-container/resolvers/survey-result.resolver';
import { SurveyViewformResolver } from '../../main-view/admin-view/survey-container/resolvers/survey-viewform.resolver';
import { SurveyContainerComponent } from './survey-container.component';

const surveyContainerRoutes: Routes = [
  {
    path: '',
    component: SurveyContainerComponent,
    children: [
      {
        path: 'create/:id',
        loadChildren:
          './../../main-view/admin-view/survey-container/survey-creator/survey-creator.module#SurveyCreatorModule',
        canLoad: [AuthGuard],
        resolve: {
          cres: SurveyCreatorResolver
        },
        data: { preload: true, delay: true }
      },
      {
        path: 'viewform/:id',
        loadChildren:
          './../../survey-viewform/survey-viewform.module#SurveyViewformModule'
        // canLoad: [SurveyGuard],
        // canLoad: [RouteGuard]
      },
      {
        path: 'viewform/:id/:hash',
        loadChildren:
          './../../survey-viewform/survey-viewform.module#SurveyViewformModule',
        resolve: {
          cres: SurveyViewformResolver
        },
        data: { preload: true, delay: true }
        // canLoad: [SurveyGuard],
        // canLoad: [RouteGuard]
      },
      {
        path: 'result/:id',
        loadChildren:
          './../../main-view/admin-view/survey-container/survey-result.module#SurveyResultModule',
        canLoad: [AuthGuard],
        resolve: {
          cres: SurveyResultResolver
        },
        data: { preload: true, delay: false }
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
