import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminViewComponent } from './admin-view.component';
import { Routes } from '../../../../node_modules/@angular/router';

export const routes: Routes = [{ path: '', component: AdminViewComponent }];

@NgModule({
  imports: [CommonModule],
  declarations: [AdminViewComponent]
})
export class AdminViewModule {}
