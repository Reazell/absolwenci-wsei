import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InfoComponent } from './info.component';
import { InfoRoutingModule } from './info.routing';

@NgModule({
  imports: [CommonModule, InfoRoutingModule],
  declarations: [InfoComponent]
})
export class InfoModule {}
