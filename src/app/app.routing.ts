import { NgModule } from '@angular/core';
// import { DashboardComponent } from './dashboard/dashboard.component';
import { AppComponent } from './app.component';
import { Routes, RouterModule } from '@angular/router';

const appRoutes: Routes = [
  // {
  //   path: '',
  //   component: DashboardComponent,
  //   canActivate: [AuthGuard]
  // },

  { path: '', redirectTo: '/auth', pathMatch: 'full' },
  { path: 'auth', loadChildren: './auth/auth.module#AuthModule' }
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
  // {
  //   path: 'webMail',
  //   loadChildren: './webmail/webmail.module#WebmailModule',
  //   canActivate: [AuthGuard]
  // },
  // { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
