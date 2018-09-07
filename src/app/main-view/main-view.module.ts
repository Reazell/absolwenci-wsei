import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainViewComponent } from './main-view.component';
import { MainViewRoutingModule } from './main-view.routing';
import { MatSidenavModule } from '@angular/material';

@NgModule({
  imports: [CommonModule, MainViewRoutingModule, MatSidenavModule],
  declarations: [MainViewComponent]
})
export class MainViewModule {}
