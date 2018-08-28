import { PoolingViewComponent } from './pooling-space/pooling-view/pooling-view.component';
import { PoolingListModule } from './pooling-list/pooling-list.module';
import { GroupListModule } from './group-list/group-list.module';
import { MaterialsModule } from './../../materials/materials.module';
import { AdminViewRoutingModule } from './admin-view.routing';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminViewComponent } from './admin-view.component';
import { MatSidenavModule } from '../../../../node_modules/@angular/material';
import { ReactiveFormsModule } from '../../../../node_modules/@angular/forms';
import { PoolingSearchModule } from './pooling-search/pooling-search.module';
import { ManageBarModule } from './manage-bar/manage-bar.module';


@NgModule({
  imports: [
    CommonModule,
    MaterialsModule,
    ReactiveFormsModule,
    PoolingSearchModule,
    ManageBarModule,
    GroupListModule,
    PoolingListModule,
    AdminViewRoutingModule,
    MatSidenavModule
  ],
  declarations: [AdminViewComponent]
})
export class AdminViewModule {}
