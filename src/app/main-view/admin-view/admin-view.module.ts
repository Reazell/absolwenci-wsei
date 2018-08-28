import { MaterialsModule } from './../../materials/materials.module';
import { AdminViewRoutingModule } from './admin-view.routing';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminViewComponent } from './admin-view.component';
import { Routes, RouterModule } from '../../../../node_modules/@angular/router';
import { MatSidenavModule } from '../../../../node_modules/@angular/material';
import { ReactiveFormsModule } from '../../../../node_modules/@angular/forms';

export const routes: Routes = [{ path: '', component: AdminViewComponent }];

@NgModule({
  imports: [
    CommonModule,
    MaterialsModule,
    ReactiveFormsModule,
    // SearchMailModule,
    // ManageBarModule,
    // CatalogsListModule,
    // MailListModule,
    RouterModule.forChild(routes),
    // AdminViewRoutingModule,
    MatSidenavModule
  ],
  declarations: [AdminViewComponent]
})
export class AdminViewModule {}
