import { PoolingCreatorComponent } from './pooling-creator.component';
import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

const adminRoutes: Routes = [
  {
    path: '',
    component: PoolingCreatorComponent,
    // children: [
    //   {
    //     path: '',
    //     loadChildren: './pooling-space/pooling-space.module#PoolingSpaceModule'
    //   }
    // ]
  }
];

// export const routing = RouterModule.forRoot(appRoutes);

@NgModule({
  imports: [RouterModule.forChild(adminRoutes)],
  exports: [RouterModule]
})
export class PoolingCreatorRoutingModule { }
