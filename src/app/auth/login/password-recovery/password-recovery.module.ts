import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { ProgressBarModule } from 'primeng/progressbar';
import { MaterialsModule } from '../../../materials/materials.module';
import { PasswordRecoveryComponent } from './password-recovery.component';

export const routes: Routes = [
  { path: '', component: PasswordRecoveryComponent }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes),
    MaterialsModule,
    ReactiveFormsModule,
    CommonModule,
    ProgressBarModule
  ],
  declarations: [PasswordRecoveryComponent],
  exports: [PasswordRecoveryComponent]
})
export class PasswordRecoveryModule {}
