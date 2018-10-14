import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard.component';

const dashboards = {
  main: 'main',
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
const adminString = mainString + dashboards.main + outletString;
const surveyString = mainString + dashboards.survey + outletString;
const usersString = mainString + dashboards.users + outletString;
// console.log(usersString);

const routes: Routes = [
  {
    path: '',
    component: DashboardComponent,
    children: [
      {
        path: dashboards.main,
        children: [
          {
            path: '',
            redirectTo: adminString,
            pathMatch: 'full'
          },
          {
            path: outletPath,
            outlet: outlets.sidebar,
            loadChildren:
              './../../main-view/admin-view/dashboard-views/admin-dashboard/admin-sidenav/admin-sidenav.module#AdminSidenavModule',
            data: { preload: true, delay: true }
          },
          {
            path: outletPath,
            outlet: outlets.manage,
            loadChildren:
              './../../main-view/admin-view/dashboard-views/admin-dashboard/admin-content/admin-content.module#AdminContentModule',
            data: { preload: true, delay: true }
          }
        ]
      },
      {
        path: dashboards.survey,
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
              './../../main-view/admin-view/dashboard-views/survey-dashboard/survey-sidenav/survey-sidenav.module#SurveySidenavModule',
            data: { preload: true, delay: true }
          },
          {
            path: outletPath,
            outlet: outlets.manage,
            loadChildren:
              './../../main-view/admin-view/dashboard-views/survey-dashboard/survey-content/survey-content.module#SurveyContentModule',
            data: { preload: true, delay: true }
          }
        ]
      },
      {
        path: dashboards.users,
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
              './../../main-view/admin-view/dashboard-views/users-dashboard/users-sidenav/users-sidenav.module#UsersSidenavModule',
            data: { preload: true, delay: true }
          },
          {
            path: outletPath,
            outlet: outlets.manage,
            loadChildren:
              './../../main-view/admin-view/dashboard-views/users-dashboard/users-content/users-content.module#UsersContentModule',
            data: { preload: true, delay: true }
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