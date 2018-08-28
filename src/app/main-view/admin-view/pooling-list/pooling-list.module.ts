import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PoolingListComponent } from './pooling-list.component';
import { PoolingTileComponent } from './pooling-tile/pooling-tile.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [PoolingListComponent, PoolingTileComponent],
  exports: [PoolingListComponent, PoolingTileComponent]
})
export class PoolingListModule { }
