import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GroupListComponent } from './group-list.component';
import { MatToolbarModule } from '@angular/material';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

@NgModule({
  imports: [
    CommonModule,
    MatToolbarModule,
    FontAwesomeModule
  ],
  declarations: [GroupListComponent],
  exports: [GroupListComponent]
})
export class GroupListModule { }
