import { MaterialsModule } from '../../../materials/materials.module';
import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ManageBarComponent } from './manage-bar.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

@NgModule({
  imports: [CommonModule, RouterModule, FontAwesomeModule, MaterialsModule],
  declarations: [ManageBarComponent],
  exports: [ManageBarComponent]
})
export class ManageBarModule {}
