import { SettingsComponent } from './settings.component';
import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

const settingsRoutes: Routes = [
  {
    path: '',
    component: SettingsComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(settingsRoutes)],
  exports: [RouterModule]
})
export class SettingsRoutingModule {}
