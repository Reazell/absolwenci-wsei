import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SettingsComponent } from './settings.component';
import { SettingsRoutingModule } from './settings.routing';
import { MatTabsModule, MatExpansionModule } from '@angular/material';
import { MaterialsModule } from '../../materials/materials.module';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { ProgressBarModule } from 'primeng/progressbar';
import { ProfileSettingsComponent } from './profile-settings/profile-settings.component';
import { MainSettingsComponent } from './main-settings/main-settings.component';

@NgModule({
  imports: [
    CommonModule,
    SettingsRoutingModule,
    MatTabsModule,
    MaterialsModule,
    FontAwesomeModule,
    ReactiveFormsModule,
    FormsModule,
    ProgressBarModule,
    MatExpansionModule
  ],
  declarations: [SettingsComponent, ProfileSettingsComponent, MainSettingsComponent]
})
export class SettingsModule {}
