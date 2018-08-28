import { PoolingWriteComponent } from './pooling-write/pooling-write.component';
import { PoolingDefaultComponent } from './pooling-default/pooling-default.component';
import { PoolingViewComponent } from './pooling-view/pooling-view.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PoolingSpaceComponent } from './pooling-space.component';
import { PoolingSpaceRoutingModule } from './pooling-space.routing';

@NgModule({
  imports: [
    CommonModule,
    PoolingSpaceRoutingModule
  ],
  declarations: [PoolingSpaceComponent, PoolingViewComponent, PoolingDefaultComponent, PoolingWriteComponent]
})
export class PoolingSpaceModule { }
