import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PasswordChangeComponent } from './password-change.component';
import { Routes, RouterModule } from '../../../../node_modules/@angular/router';
import { MaterialsModule } from '../../materials/materials.module';
import { ReactiveFormsModule } from '../../../../node_modules/@angular/forms';
import { ProgressBarModule } from '../../../../node_modules/primeng/progressbar';

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
