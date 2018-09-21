import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SurveyCreatorComponent } from './survey-creator.component';

const adminRoutes: Routes = [
  {
    path: '',
    component: SurveyCreatorComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(adminRoutes)],
  exports: [RouterModule]
})
export class SurveyCreatorRoutingModule {}
