import { AuthComponent } from './auth.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GuidGuard } from './other/guid.auth';
import { AuthGuard } from './other/guard.auth';
// import { AuthGuard } from './auth/guard.auth';

const authRoutes: Routes = [
  {
    path: '',
    component: AuthComponent,
    children: [
      { path: 'login', loadChildren: './login/login.module#LoginModule' },
      {
        path: 'register',
        loadChildren: './register/register.module#RegisterModule'
      },
      {
        path: 'activation/:token',
        loadChildren:
          './account-activation/account-activation.module#AccountActivationModule',
        canActivate: [GuidGuard]
      },
      {
        path: 'restore/:token',
        loadChildren:
          './restore-password/restore-password.module#RestorePasswordModule',
        canActivate: [GuidGuard]
      },
      {
        path: 'recovery',
        loadChildren:
          './login/password-recovery/password-recovery.module#PasswordRecoveryModule'
      },
      {
        path: 'admin',
        loadChildren: './admin/admin.module#AdminModule'
      },
      {
        path: 'password',
        loadChildren:
          './password-change/password-change.module#PasswordChangeModule',
          canLoad: [AuthGuard]
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(authRoutes)]
})
export class AuthRoutingModule {}
