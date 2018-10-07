import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard.component';

const dashboards = {
  survey: 'survey',
  users: 'users'
};
const outlets = {
  sidebar: 's',
  manage: 'm'
};
const outletPath = 'a';
const mainString = '/app/admin/d/';
const outletString =
  '/(' +
  outlets.sidebar +
  ':' +
  outletPath +
  '//' +
  outlets.manage +
  ':' +
  outletPath +
  ')';
const surveyString = mainString + dashboards.survey + outletString;
const usersString = mainString + dashboards.users + outletString;

const routes: Routes = [
  {
    path: '',
    component: DashboardComponent,
    children: [
      {
        path: 'survey',
        children: [
          {
            path: '',
            redirectTo: surveyString,
            pathMatch: 'full'
          },
          {
            path: outletPath,
            outlet: outlets.sidebar,
            loadChildren:
              './../survey-dashboard/survey-sidenav/survey-sidenav.module#SurveySidenavModule'
          },
          {
            path: outletPath,
            outlet: outlets.manage,
            loadChildren:
              './../survey-dashboard/survey-content/survey-content.module#SurveyContentModule'
          }
        ]
      },
      {
        path: 'users',
        children: [
          {
            path: '',
            redirectTo: usersString,
            pathMatch: 'full'
          },
          {
            path: outletPath,
            outlet: outlets.sidebar,
            loadChildren:
              './dashboard-sidenav/dashboard-sidenav.module#DashboardSidenavModule'
          },
          {
            path: outletPath,
            outlet: outlets.manage,
            loadChildren:
              './dashboard-content/dashboard-content.module#DashboardContentModule'
          }
        ]
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DashboardRoutingModule {}
