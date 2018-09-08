import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainViewComponent } from './main-view.component';
import { MainViewRoutingModule } from './main-view.routing';
import { MatSidenavModule } from '@angular/material';
import { SurveyService } from './services/survey.services';
import { SurveyGuard } from '../others/survey.auth';
import { RouteGuard } from '../others/route.auth';

@NgModule({
  imports: [CommonModule, MainViewRoutingModule, MatSidenavModule],
  declarations: [MainViewComponent],
  providers: [SurveyService]
})
export class MainViewModule {}
