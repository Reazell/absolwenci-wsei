import { AuthRoutingModule } from './auth.routing';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AuthComponent } from './auth.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    AuthRoutingModule
  ],
  declarations: [AuthComponent]
})
export class AuthModule {}
