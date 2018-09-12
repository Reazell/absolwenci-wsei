import { SharedService } from '../../services/shared.service';
import { RegisterComponent } from './register.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MaterialsModule } from '../../materials/materials.module';
import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatRadioModule } from '@angular/material';
import { ProgressBarModule } from 'primeng/progressbar';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

export const routes: Routes = [{ path: '', component: RegisterComponent }];

@NgModule({
  imports: [
    RouterModule.forChild(routes),
    MaterialsModule,
    ReactiveFormsModule,
    CommonModule,
    MatRadioModule,
    ProgressBarModule,
    FontAwesomeModule
  ],
  providers: [SharedService],
  declarations: [RegisterComponent],
  exports: [RegisterComponent]
})
export class RegisterModule {}
