import { RoleGuard } from './../auth/other/role.auth';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainViewComponent } from './main-view.component';
import { MainViewRoutingModule } from './main-view.routing';
import { MatSidenavModule } from '@angular/material';
import { SurveyService } from './services/survey.services';

@NgModule({
  imports: [CommonModule, MainViewRoutingModule, MatSidenavModule],
  declarations: [MainViewComponent],
  providers: [SurveyService, RoleGuard]
})
export class MainViewModule {}
