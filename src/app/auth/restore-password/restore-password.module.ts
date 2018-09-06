import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RestorePasswordComponent } from './restore-password.component';
import { Routes, RouterModule } from '@angular/router';
import { MaterialsModule } from '../../materials/materials.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

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
