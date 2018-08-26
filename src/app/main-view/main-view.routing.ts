import { MainViewComponent } from './main-view.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const appRoutes: Routes = [
  { path: '', component: MainViewComponent }
  // { path: 'auth', loadChildren: './auth/auth.module#AuthModule' }
];

@NgModule({
  imports: [RouterModule.forChild(appRoutes)],
  exports: [RouterModule]
})
export class MainViewRoutingModule {}
