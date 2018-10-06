import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard.component';

const routes: Routes = [
  {
    path: '',
    component: DashboardComponent,
    children: [
      // {
      //   path: '',
      //   redirectTo: 'survey',
      //   pathMatch: 'full'
      // },
      // {
      //   path: 'survey',
      //   children: [
      //   ]
      // },
      // {
      //   path: 'users',
      //   children: [
      //     {
      //       path: '',
      //       component: SurveyBarComponent,
      //       outlet: 'manage',
      //       canLoad: [AuthGuard]
      //     },
      //     {
      //       path: '',
      //       component: GroupListComponent,
      //       outlet: 'sidebar',
      //       canLoad: [AuthGuard]
      //     }
      //   ]
      // }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DashboardRoutingModule {}
