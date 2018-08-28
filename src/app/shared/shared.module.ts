import { AppBarComponent } from './bar/app-bar.component';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialsModule } from '../materials/materials.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedService } from '../services/shared.service';

@NgModule({
  imports: [
    CommonModule,
    MaterialsModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule
  ],
  declarations: [AppBarComponent],
  exports: [AppBarComponent],
  providers: [SharedService],
  entryComponents: []
})
export class SharedModule {}
