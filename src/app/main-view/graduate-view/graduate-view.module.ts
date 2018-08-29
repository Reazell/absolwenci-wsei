import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GraduateViewComponent } from './graduate-view.component';
import { GraduateViewRoutingModule } from './graduate-view.routing';

@NgModule({
  imports: [
    CommonModule,
    GraduateViewRoutingModule
  ],
  declarations: [GraduateViewComponent]
})
export class GraduateViewModule { }
