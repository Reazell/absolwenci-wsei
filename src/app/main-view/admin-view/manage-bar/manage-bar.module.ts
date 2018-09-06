import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ManageBarComponent } from './manage-bar.component';
import { FontAwesomeModule } from '../../../../../node_modules/@fortawesome/angular-fontawesome';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    FontAwesomeModule
  ],
  declarations: [ManageBarComponent],
  exports: [ManageBarComponent]
})
export class ManageBarModule { }
