import { RouterModule, Routes } from '@angular/router';
import { DraggableModule } from './../draggable.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SortableListComponent } from './sortable-list.component';
import { ReactiveFormsModule, FormsModule } from '../../../../../../node_modules/@angular/forms';
import { MatRadioModule, MatCheckboxModule } from '../../../../../../node_modules/@angular/material';
import { MaterialsModule } from '../../../../materials/materials.module';
import { FontAwesomeModule } from '../../../../../../node_modules/@fortawesome/angular-fontawesome';

export const routes: Routes = [{ path: '', component: SortableListComponent }];

@NgModule({
  imports: [
    RouterModule.forChild(routes),
    CommonModule,
    DraggableModule,
    ReactiveFormsModule,
    FormsModule,
    MaterialsModule,
    MatRadioModule,
    MatCheckboxModule,
    FontAwesomeModule,
    MaterialsModule
  ],
  declarations: [SortableListComponent]
})
export class SortableListModule { }
