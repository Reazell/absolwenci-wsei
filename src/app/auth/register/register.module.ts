import { RegisterComponent } from './register.component';
import { SharedModule } from './../../shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialsModule } from './../../materials/materials.module';
import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

export const routes: Routes = [{ path: '', component: RegisterComponent }];

@NgModule({
  imports: [
    RouterModule.forChild(routes),
    MaterialsModule,
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    SharedModule
  ],
  declarations: [RegisterComponent],
  entryComponents: [],
  exports: [RegisterComponent]
})
export class RegisterModule { }
