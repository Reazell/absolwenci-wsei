import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './auth/other/guard.auth';

const appRoutes: Routes = [
  // { path: '', redirectTo: '/auth/login', pathMatch: 'full' },
  { path: 'auth', loadChildren: './auth/auth.module#AuthModule' },
  {
    path: 'app',
    loadChildren: './main-view/main-view.module#MainViewModule',
    canLoad: [AuthGuard]
  },
  {
    path: 'info',
    loadChildren: './info/info.module#InfoModule'
  },

  { path: '**', redirectTo: '/auth/login' }
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
