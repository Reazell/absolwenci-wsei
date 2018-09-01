import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PoolingCreatorComponent } from './pooling-creator.component';
import { PoolingCreatorRoutingModule } from './pooling-creator.routing';
import { MaterialsModule } from '../../../materials/materials.module';
import { MatRadioModule } from '../../../../../node_modules/@angular/material';
import { MatCheckboxModule } from '@angular/material/checkbox';

@NgModule({
  imports: [
    CommonModule,
    PoolingCreatorRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    MaterialsModule,
    MatRadioModule,
    MatCheckboxModule
  ],
  declarations: [PoolingCreatorComponent]
})
export class PoolingCreatorModule {}
