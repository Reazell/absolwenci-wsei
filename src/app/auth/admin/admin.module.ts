import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { MaterialsModule } from '../../materials/materials.module';
import { ProgressBarModule } from 'primeng/progressbar';
import { SharedService } from '../../services/shared.service';
import { AdminComponent } from './admin.component';

export const routes: Routes = [{ path: '', component: AdminComponent }];

@NgModule({
  imports: [
    RouterModule.forChild(routes),
    MaterialsModule,
    ReactiveFormsModule,
    CommonModule,
    ProgressBarModule
  ],
  providers: [SharedService],
  declarations: [AdminComponent]
})
export class AdminModule {}
