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
              './../../main-view/admin-view/admin-dashboard/admin-sidenav/admin-sidenav.module#AdminSidenavModule'
          },
          {
            path: outletPath,
            outlet: outlets.manage,
            loadChildren:
              './../../main-view/admin-view/admin-dashboard/admin-content/admin-content.module#AdminContentModule'
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
              './../../main-view/admin-view/survey-dashboard/survey-sidenav/survey-sidenav.module#SurveySidenavModule'
          },
          {
            path: outletPath,
            outlet: outlets.manage,
            loadChildren:
              './../../main-view/admin-view/survey-dashboard/survey-content/survey-content.module#SurveyContentModule'
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
            './../../main-view/admin-view/users-dashboard/users-sidenav/users-sidenav.module#UsersSidenavModule'
          },
          {
            path: outletPath,
            outlet: outlets.manage,
            loadChildren:
            './../../main-view/admin-view/users-dashboard/users-content/users-content.module#UsersContentModule'
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
