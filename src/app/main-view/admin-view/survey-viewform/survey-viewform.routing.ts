import { SurveySentComponent } from './survey-sent/survey-sent.component';
import { SurveyViewformComponent } from './survey-viewform.component';
import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

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
