import { GuidGuard } from './auth/other/guid.auth';
import { AuthGuard } from './auth/other/guard.auth';
import { JwtInterceptor } from './auth/other/jwt.interceptor';
import { UserService } from './auth/services/user.service';
import { AuthenticationService } from './auth/services/authentication.service';
import { SharedModule } from './shared/shared.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { AppConfig } from './app.config';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { MaterialsModule } from './materials/materials.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { AppRoutingModule } from './app.routing';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { library } from '@fortawesome/fontawesome-svg-core';
import {
  faTimes,
  faTrash,
  faBars,
  faPlus,
  faCopy,
  faGripHorizontal,
  faPen,
  faGraduationCap,
  faBriefcase,
  faCog,
  faUserAlt,
  faSearch
} from '@fortawesome/free-solid-svg-icons';

library.add(
  faTimes,
  faBars,
  faPlus,
  faTrash,
  faCopy,
  faGripHorizontal,
  faPen,
  faGraduationCap,
  faBriefcase,
  faCog,
  faUserAlt,
  faSearch
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
