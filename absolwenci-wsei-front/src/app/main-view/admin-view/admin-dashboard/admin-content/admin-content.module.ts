import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { Routes } from '@angular/router';
import { AdminContentComponent } from './admin-content.component';

export const routes: Routes = [{ path: '', component: AdminContentComponent }];

@NgModule({
  imports: [CommonModule],
  declarations: [AdminContentComponent]
})
export class AdminContentModule {}
