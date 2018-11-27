import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StudentViewComponent } from './student-view.component';
import { StudentViewRoutingModule } from './student-view.routing';
import { StudentProfileComponent } from './student-profile/student-profile.component';

@NgModule({
  imports: [
    CommonModule,
    StudentViewRoutingModule
  ],
  declarations: [StudentViewComponent, StudentProfileComponent]
})
export class StudentViewModule { }
