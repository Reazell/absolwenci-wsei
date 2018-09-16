import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PasswordChangeComponent } from './password-change.component';
import { Routes, RouterModule } from '@angular/router';
import { MaterialsModule } from '../../materials/materials.module';
import { ReactiveFormsModule } from '@angular/forms';
import { ProgressBarModule } from 'primeng/progressbar';

export const routes: Routes = [{ path: '', component: PasswordChangeComponent }];

@NgModule({
  imports: [
    RouterModule.forChild(routes),
    MaterialsModule,
    ReactiveFormsModule,
    CommonModule,
    ProgressBarModule
  ],
  declarations: [PasswordChangeComponent]
})
export class PasswordChangeModule { }
