import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PoolingSearchComponent } from './pooling-search.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [PoolingSearchComponent],
  exports: [PoolingSearchComponent]
})
export class PoolingSearchModule { }
