import { AuthRoutingModule } from './auth.routing';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule, Routes } from '@angular/router';
import { MaterialsModule } from './../materials/materials.module';
import { AuthComponent } from './auth.component';
import { RegisterComponent } from './register/register.component';

@NgModule({
  imports: [
    CommonModule,
    MaterialsModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    HttpModule,
    AuthRoutingModule
  ],
  declarations: [AuthComponent],
  exports: [AuthComponent]
})
export class AuthModule {}
