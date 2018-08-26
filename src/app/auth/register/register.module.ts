import { RegisterComponent } from './register.component';
import { SharedModule } from './../../shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialsModule } from './../../materials/materials.module';
import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatRadioModule } from '../../../../node_modules/@angular/material';
import { ProgressBarModule } from 'primeng/progressbar';

export const routes: Routes = [{ path: '', component: RegisterComponent }];

@NgModule({
  imports: [
    RouterModule.forChild(routes),
    MaterialsModule,
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    SharedModule,
    MatRadioModule,
    ProgressBarModule
  ],
  declarations: [RegisterComponent],
  entryComponents: [],
  exports: [RegisterComponent]
})
export class RegisterModule {}
