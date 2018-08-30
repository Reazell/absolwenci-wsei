import { ReactiveFormsModule } from '@angular/forms';
import { PoolingService } from './../../services/pooling.services';
import { PoolingWriteComponent } from './pooling-write/pooling-write.component';
import { PoolingDefaultComponent } from './pooling-default/pooling-default.component';
import { PoolingViewComponent } from './pooling-view/pooling-view.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PoolingSpaceComponent } from './pooling-space.component';
import { PoolingSpaceRoutingModule } from './pooling-space.routing';
import { MatFormFieldModule } from '../../../../../node_modules/@angular/material';

@NgModule({
  imports: [
    CommonModule,
    PoolingSpaceRoutingModule,
    ReactiveFormsModule,
    MatFormFieldModule
  ],
  declarations: [
    PoolingSpaceComponent,
    PoolingViewComponent,
    PoolingDefaultComponent,
    PoolingWriteComponent
  ],
  providers: [PoolingService]
})
export class PoolingSpaceModule {}
