import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StudentComponent } from './student.component';
import { Routes, RouterModule } from '@angular/router';

export const routes: Routes = [{ path: '', component: StudentComponent }];

@NgModule({
  imports: [CommonModule, RouterModule.forChild(routes)],
  declarations: [StudentComponent],
  exports: [StudentComponent]
})
export class StudentModule {}
