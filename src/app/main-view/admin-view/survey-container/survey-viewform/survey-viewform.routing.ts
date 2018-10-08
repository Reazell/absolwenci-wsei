import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SurveyViewformComponent } from './survey-viewform.component';

const surveyViewformRoutes: Routes = [
  {
    path: '',
    component: SurveyViewformComponent
  }
  // {
  //   path: 'formResponse',
  //   component: SurveySentComponent
  // }
];

@NgModule({
  imports: [RouterModule.forChild(surveyViewformRoutes)],
  exports: [RouterModule]
})
export class SurveyViewformRoutingModule {}
