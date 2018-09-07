import { AdminViewComponent } from './admin-view.component';
import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

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
      './survey-viewform/survey-viewform.module#SurveyViewformModule'
  }
];

// export const routing = RouterModule.forRoot(appRoutes);

@NgModule({
  imports: [RouterModule.forChild(adminRoutes)],
  exports: [RouterModule]
})
export class AdminViewRoutingModule {}
