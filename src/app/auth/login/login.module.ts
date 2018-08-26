import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login.component';
import { Routes, RouterModule } from '@angular/router';
import { PasswordRecoveryComponent } from './password-recovery/password-recovery.component';
import { SharedModule } from './../../shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialsModule } from './../../materials/materials.module';
import { ProgressBarModule } from '../../../../node_modules/primeng/progressbar';

export const routes: Routes = [{ path: '', component: LoginComponent }];

@NgModule({
  imports: [
    RouterModule.forChild(routes),
    MaterialsModule,
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    SharedModule,
    ProgressBarModule
  ],
  declarations: [LoginComponent, PasswordRecoveryComponent],
  entryComponents: [PasswordRecoveryComponent],
  exports: [LoginComponent]
})
export class LoginModule {}
