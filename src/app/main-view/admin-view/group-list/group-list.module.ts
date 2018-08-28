import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GroupListComponent } from './group-list.component';
import { MatToolbarModule } from '@angular/material';

@NgModule({
  imports: [
    CommonModule,
    MatToolbarModule
  ],
  declarations: [GroupListComponent],
  exports: [GroupListComponent]
})
export class GroupListModule { }
