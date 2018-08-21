import { SharedModule } from './shared/shared.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { AppConfig } from './app.config';
import {
  HTTP_INTERCEPTORS,
  HttpClientModule
} from '../../node_modules/@angular/common/http';
import { JwtInterceptor } from './auth/jwt.interceptor';
import { MaterialsModule } from './materials/materials.module';
import {
  FormsModule,
  ReactiveFormsModule
} from '../../node_modules/@angular/forms';
import { HttpModule } from '../../node_modules/@angular/http';
import { AppRoutingModule } from './app.routing';

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
    SharedModule
  ],
  providers: [
    // AppConfig,
    // {
    //   provide: HTTP_INTERCEPTORS,
    //   useClass: JwtInterceptor,
    //   multi: true
    // }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
