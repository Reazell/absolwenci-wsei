import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GroupListComponent } from './group-list.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [GroupListComponent],
  exports: [GroupListComponent]
})
export class GroupListModule { }
