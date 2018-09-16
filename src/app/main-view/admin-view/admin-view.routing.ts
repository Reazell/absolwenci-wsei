import { AdminViewComponent } from './admin-view.component';
import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { SurveyGuard } from '../../others/survey.auth';
import { RouteGuard } from '../../others/route.auth';

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
    path: 'create/:id',
    loadChildren: './survey-creator/survey-creator.module#SurveyCreatorModule'
  },
  {
    path: 'viewform/:id',
    loadChildren:
      './survey-viewform/survey-viewform.module#SurveyViewformModule',
    // canLoad: [SurveyGuard],
    // canActivate: [RouteGuard]
  },
  {
    path: 'list',
    loadChildren:
      './draggable/sortable-list/sortable-list.module#SortableListModule'
   }
];

// export const routing = RouterModule.forRoot(appRoutes);

@NgModule({
  imports: [RouterModule.forChild(adminRoutes)],
  exports: [RouterModule]
})
export class AdminViewRoutingModule {}
