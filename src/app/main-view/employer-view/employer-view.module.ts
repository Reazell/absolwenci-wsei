import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployerViewComponent } from './employer-view.component';
import { EmployerViewRoutingModule } from './employer-view.routing';

@NgModule({
  imports: [
    CommonModule,
    EmployerViewRoutingModule
  ],
  declarations: [EmployerViewComponent]
})
export class EmployerViewModule { }
