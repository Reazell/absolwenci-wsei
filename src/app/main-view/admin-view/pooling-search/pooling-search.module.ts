import { MatToolbarModule } from '@angular/material/toolbar';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PoolingSearchComponent } from './pooling-search.component';

@NgModule({
  imports: [
    CommonModule,
    MatToolbarModule
  ],
  declarations: [PoolingSearchComponent],
  exports: [PoolingSearchComponent]
})
export class PoolingSearchModule { }
