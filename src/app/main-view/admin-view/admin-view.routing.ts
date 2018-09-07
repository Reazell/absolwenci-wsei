import { AdminViewComponent } from './admin-view.component';
import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { SurveyGuard } from '../../others/survey.auth';

const adminRoutes: Routes = [
  {
    path: '',
    component: AdminViewComponent,
    children: [
      {
        path: '',
        loadChildren: './survey-space/survey-space.module#SurveySpaceModule'
      }
    ]
  },
  {
    path: 'create',
    loadChildren: './survey-creator/survey-creator.module#SurveyCreatorModule'
  },
  {
    path: 'viewform',
    loadChildren:
      './survey-viewform/survey-viewform.module#SurveyViewformModule',
    canLoad: [SurveyGuard]
  }
];

// export const routing = RouterModule.forRoot(appRoutes);

@NgModule({
  imports: [RouterModule.forChild(adminRoutes)],
  exports: [RouterModule]
})
export class AdminViewRoutingModule {}
