import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SettingsComponent } from './settings.component';
import { SettingsRoutingModule } from './settings.routing';
import { MatTabsModule } from '../../../../node_modules/@angular/material';
import { MaterialsModule } from '../../materials/materials.module';
import { FontAwesomeModule } from '../../../../node_modules/@fortawesome/angular-fontawesome';

@NgModule({
  imports: [
    CommonModule,
    SettingsRoutingModule,
    MatTabsModule,
    MaterialsModule,
    FontAwesomeModule
  ],
  declarations: [SettingsComponent]
})
export class SettingsModule {}
