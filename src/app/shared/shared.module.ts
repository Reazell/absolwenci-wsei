import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { RouterModule } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { MaterialsModule } from '../materials/materials.module';
import { AppBarComponent } from './bar/app-bar.component';
import { UserInfoComponent } from './bar/user-info/user-info.component';
import { LoadingScreenComponent } from './loading-screen/loading-screen.component';
import { ProxyRouteComponent } from './proxy-route/proxy-route.component';

@NgModule({
  imports: [
    CommonModule,
    MaterialsModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    FontAwesomeModule,
    MatProgressSpinnerModule
  ],
  declarations: [
    AppBarComponent,
    UserInfoComponent,
    LoadingScreenComponent,
    ProxyRouteComponent
  ],
  exports: [AppBarComponent, LoadingScreenComponent, ProxyRouteComponent]
})
export class SharedModule {}
