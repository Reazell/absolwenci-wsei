import { CommonModule } from '@angular/common';
import { MatSidenavModule } from '@angular/material';
import { NgModule } from '../../../node_modules/@angular/core';
import { RoleGuard } from '../auth/other/role.auth';
import { SurveyService } from './admin-view/survey-container/services/survey.services';
import { MainViewComponent } from './main-view.component';
import { MainViewRoutingModule } from './main-view.routing';

@NgModule({
  imports: [CommonModule, MainViewRoutingModule, MatSidenavModule],
  declarations: [MainViewComponent],
  providers: [SurveyService, RoleGuard]
})
export class MainViewModule {}
