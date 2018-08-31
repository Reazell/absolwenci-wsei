import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RestorePasswordComponent } from './restore-password.component';
import { Routes, RouterModule } from '../../../../node_modules/@angular/router';
import { MaterialsModule } from '../../materials/materials.module';
import { FormsModule, ReactiveFormsModule } from '../../../../node_modules/@angular/forms';
import { HttpModule } from '../../../../node_modules/@angular/http';

export const routes: Routes = [
  { path: '', component: RestorePasswordComponent }
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    MaterialsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpModule
  ],
  declarations: [RestorePasswordComponent]
})
export class RestorePasswordModule {}
