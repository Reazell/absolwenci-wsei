import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { library } from '@fortawesome/fontawesome-svg-core';
import { faChartBar, faEye, faSave } from '@fortawesome/free-regular-svg-icons';
import {
  faBars,
  faBriefcase,
  faClone,
  faCog,
  faEllipsisH,
  faEllipsisV,
  faGraduationCap,
  faGripHorizontal,
  faPen,
  faPlus,
  faSearch,
  faTimes,
  faTrash,
  faUserAlt
} from '@fortawesome/free-solid-svg-icons';
import { AppComponent } from './app.component';
import { AppConfig } from './app.config';
import { AppRoutingModule } from './app.routing';
import { AuthGuard } from './auth/other/guard.auth';
import { GuidGuard } from './auth/other/guid.auth';
import { JwtInterceptor } from './auth/other/jwt.interceptor';
import { AuthenticationService } from './auth/services/authentication.service';
import { UserService } from './auth/services/user.service';
import { MaterialsModule } from './materials/materials.module';
import { SharedModule } from './shared/shared.module';

library.add(
  faTimes,
  faBars,
  faPlus,
  faTrash,
  faGripHorizontal,
  faPen,
  faGraduationCap,
  faBriefcase,
  faCog,
  faEye,
  faClone,
  faUserAlt,
  faEllipsisV,
  faSearch,
  faEllipsisH,
  faSave,
  faChartBar
);

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    MaterialsModule,
    FormsModule,
    HttpClientModule,
    HttpModule,
    ReactiveFormsModule,
    AppRoutingModule,
    SharedModule,
    BrowserAnimationsModule,
    FontAwesomeModule
  ],
  providers: [
    AuthenticationService,
    UserService,
    AuthGuard,
    GuidGuard,
    AppConfig,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
