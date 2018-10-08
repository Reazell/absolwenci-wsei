import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UsersContentComponent } from './users-content.component';

export const routes: Routes = [{ path: '', component: UsersContentComponent }];

@NgModule({
  imports: [
    CommonModule, RouterModule.forChild(routes)
  ],
  declarations: [UsersContentComponent]
})
export class UsersContentModule { }
