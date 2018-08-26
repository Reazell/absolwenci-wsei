import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployerComponent } from './employer.component';
import { Routes, RouterModule } from '../../../../node_modules/@angular/router';

export const routes: Routes = [{ path: '', component: EmployerComponent }];

@NgModule({
  imports: [CommonModule, RouterModule.forChild(routes)],
  declarations: [EmployerComponent]
})
export class EmployerModule {}
