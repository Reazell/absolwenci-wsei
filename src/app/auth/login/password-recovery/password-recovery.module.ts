import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PasswordRecoveryComponent } from './password-recovery.component';
import { Routes, RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { MaterialsModule } from '../../../materials/materials.module';
import { ProgressBarModule } from 'primeng/progressbar';

export const routes: Routes = [{ path: '', component: PasswordRecoveryComponent }];

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
