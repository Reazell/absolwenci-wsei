import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { MaterialsModule } from '../../../../materials/materials.module';
import { GroupListComponent } from './group-list.component';

export const routes: Routes = [{ path: '', component: GroupListComponent }];

@NgModule({
  imports: [
    CommonModule,
    FontAwesomeModule,
    MaterialsModule,
    RouterModule.forChild(routes)
  ],
  declarations: [GroupListComponent],
  exports: [GroupListComponent]
})
export class GroupListModule {}
