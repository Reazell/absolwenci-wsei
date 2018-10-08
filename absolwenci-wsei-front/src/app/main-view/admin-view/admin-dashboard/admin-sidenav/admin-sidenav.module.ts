import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { Routes } from '@angular/router';
import { AdminSidenavComponent } from './admin-sidenav.component';

export const routes: Routes = [{ path: '', component: AdminSidenavComponent }];

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [AdminSidenavComponent]
})
export class AdminSidenavModule { }
