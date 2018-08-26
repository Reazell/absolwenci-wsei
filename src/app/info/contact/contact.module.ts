import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ContactComponent } from './contact.component';
import { RouterModule, Routes } from '../../../../node_modules/@angular/router';

export const routes: Routes = [{ path: '', component: ContactComponent }];

@NgModule({
  imports: [CommonModule, RouterModule.forChild(routes)],
  declarations: [ContactComponent]
})
export class ContactModule {}
