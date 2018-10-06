import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProxyRouteComponent } from '../../../../shared/proxy-route/proxy-route.component';

const routes: Routes = [{
  // path: '',
  // component: ProxyRouteComponent,
  // outlet: 'sidebar',
  // loadChildren: './../group-list/group-list.module#GroupListModule'
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DashboardContentRoutingModule {}
