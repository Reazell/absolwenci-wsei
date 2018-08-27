import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login.component';
import { Routes, RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { MaterialsModule } from '../../materials/materials.module';
import { ProgressBarModule } from 'primeng/progressbar';
import { SharedService } from '../../services/shared.service';

export const routes: Routes = [{ path: '', component: LoginComponent }];

@NgModule({
  imports: [
    RouterModule.forChild(routes),
    MaterialsModule,
    ReactiveFormsModule,
    CommonModule,
    ProgressBarModule
  ],
  providers: [SharedService],
  declarations: [LoginComponent]
})
export class LoginModule {}
