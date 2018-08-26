import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './auth/other/guard.auth';

const appRoutes: Routes = [
  // {
  //   path: '',
  //   component: DashboardComponent,
  //   canActivate: [AuthGuard]
  // },

  { path: '', redirectTo: '/auth/login', pathMatch: 'full' },
  { path: 'auth', loadChildren: './auth/auth.module#AuthModule' },
  {
    path: 'app',
    loadChildren: './main-view/main-view.module#MainViewModule',
    canActivate: [AuthGuard]
  },
  {
    path: 'info',
    loadChildren: './info/info.module#InfoModule'
  },
  // {
  //   path: 'register',
  //   loadChildren: './auth/registration/registration.module#RegistrationModule'
  // },
  // {
  //   path: 'activation',
  //   loadChildren:
  //     './auth/account-activation/account-activation.module#AccountActivationModule'
  // },
  // {
  //   path: 'restore/:token',
  //   loadChildren:
  //     './auth/restore-password/restore-password.module#RestorePasswordModule'
  // },
  // {
  //   path: 'chat',
  //   loadChildren: './chat/chat.module#ChatModule',
  //   canActivate: [AuthGuard]
  // },
  // {
  //   path: 'contacts',
  //   loadChildren: './contacts/contacts.module#ContactsModule',
  //   canActivate: [AuthGuard]
  // },

  // { path: '**', redirectTo: '/auth/login' }
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
