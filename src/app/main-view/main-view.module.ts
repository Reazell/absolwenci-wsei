import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainViewComponent } from './main-view.component';
import { MainViewRoutingModule } from './main-view.routing';

@NgModule({
  imports: [CommonModule, MainViewRoutingModule],
  declarations: [MainViewComponent]
})
export class MainViewModule {}
