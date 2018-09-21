import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SurveySentComponent } from './survey-sent/survey-sent.component';
import { SurveyViewformComponent } from './survey-viewform.component';

const adminRoutes: Routes = [
  {
    path: '',
    component: SurveyViewformComponent
    // children: [
    //   {
    //     path: 'formResponse',
    //     component: SurveySentComponent
    //   }
    // ]
  },
  // {
  //   path: 'formResponse',
  //   component: SurveySentComponent
  // }
];

@NgModule({
  imports: [RouterModule.forChild(adminRoutes)],
  exports: [RouterModule]
})
export class SurveyViewformRoutingModule {}
