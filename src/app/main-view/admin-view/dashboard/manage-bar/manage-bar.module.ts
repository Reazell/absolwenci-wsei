import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { MaterialsModule } from '../../../../materials/materials.module';
import { ManageBarComponent } from './manage-bar.component';

@NgModule({
  imports: [CommonModule, RouterModule, FontAwesomeModule, MaterialsModule],
  declarations: [ManageBarComponent],
  exports: [ManageBarComponent]
})
export class ManageBarModule {}
