import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ManageBarComponent } from './manage-bar.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [ManageBarComponent],
  exports: [ManageBarComponent]
})
export class ManageBarModule { }
