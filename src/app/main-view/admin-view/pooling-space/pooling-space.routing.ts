import { PoolingViewComponent } from './pooling-view/pooling-view.component';
import { PoolingWriteComponent } from './pooling-write/pooling-write.component';
import { PoolingDefaultComponent } from './pooling-default/pooling-default.component';
import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

const poolingRoutes: Routes = [
    {
        path: '',
        component: PoolingDefaultComponent,
    },
    {
        path: 'write',
        component: PoolingWriteComponent
    },
    {
        path: 'view',
        component: PoolingViewComponent
    }
];

// export const routing = RouterModule.forRoot(appRoutes);

@NgModule({
    imports: [RouterModule.forChild(poolingRoutes)],
    exports: [RouterModule]
})
export class PoolingSpaceRoutingModule { }
