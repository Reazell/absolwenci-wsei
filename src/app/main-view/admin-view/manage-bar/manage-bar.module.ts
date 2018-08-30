import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ManageBarComponent } from './manage-bar.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule
  ],
  declarations: [ManageBarComponent],
  exports: [ManageBarComponent]
})
export class ManageBarModule { }
