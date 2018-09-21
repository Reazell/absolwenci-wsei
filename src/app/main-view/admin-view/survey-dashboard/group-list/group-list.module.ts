import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MatToolbarModule } from '@angular/material';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { GroupListComponent } from './group-list.component';

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
