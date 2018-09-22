import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { MatRadioModule } from '@angular/material';
import { RouterModule, Routes } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { ProgressBarModule } from 'primeng/progressbar';
import { MaterialsModule } from '../../materials/materials.module';
import { SharedService } from '../../services/shared.service';
import { RegisterComponent } from './register.component';

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
  declarations: [RegisterComponent],
  exports: [RegisterComponent]
})
export class RegisterModule {}
