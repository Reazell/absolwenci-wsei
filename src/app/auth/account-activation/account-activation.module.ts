import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { AccountActivationComponent } from './account-activation.component';

export const routes: Routes = [{ path: '', component: AccountActivationComponent }];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  declarations: [AccountActivationComponent]
})
export class AccountActivationModule { }
