import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GraduateComponent } from './graduate.component';
import { Routes, RouterModule } from '../../../../node_modules/@angular/router';

export const routes: Routes = [{ path: '', component: GraduateComponent }];

@NgModule({
  imports: [CommonModule, RouterModule.forChild(routes)],
  declarations: [GraduateComponent],
  exports: [GraduateComponent]
})
export class GraduateModule {}
