import { AuthComponent } from './auth.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GuidGuard } from './other/guid.auth';
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
        loadChildren: './auth/account-activation/account-activation.module#AccountActivationModule',
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
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(authRoutes)]
})
export class AuthRoutingModule { }
