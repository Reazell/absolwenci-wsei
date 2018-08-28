import { AdminViewComponent } from './admin-view.component';
import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

const adminRoutes: Routes = [
  {
    path: '',
    component: AdminViewComponent,
    children: [
      // {
      //   path: '',
      //   redirectTo: '/pooling',
      //   pathMatch: 'full'
      // },
      {
        path: '',
        loadChildren: './pooling-space/pooling-space.module#PoolingSpaceModule'
      }
      // {
      //   path: 'newMail',
      //   loadChildren: './mail-space/mail-space.module#MailSpaceModule',
      //   // canActivate: [AuthGuard]
      // },
      // {
      //   path: 'mailView',
      //   loadChildren: './mail-space/mail-space.module#MailSpaceModule',
      //   // canActivate: [AuthGuard, MailGuard]
      // },
      // {
      //   path: 'inbox',
      //   loadChildren: './mail-list/mail-list.module#MailListModule',
      //   // canActivate: [AuthGuard]
      // },
      // {
      //   path: 'sent',
      //   loadChildren: './mail-list/mail-list.module#MailListModule',
      //   // canActivate: [AuthGuard]
      // }
    ]
  }
];

// export const routing = RouterModule.forRoot(appRoutes);

@NgModule({
  imports: [RouterModule.forChild(adminRoutes)],
  exports: [RouterModule]
})
export class AdminViewRoutingModule { }
