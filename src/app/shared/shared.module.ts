import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { MaterialsModule } from '../materials/materials.module';
import { SharedService } from '../services/shared.service';
import { AppBarComponent } from './bar/app-bar.component';
import { UserInfoComponent } from './bar/user-info/user-info.component';

@NgModule({
  imports: [
    CommonModule,
    MaterialsModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    FontAwesomeModule
  ],
  declarations: [AppBarComponent, UserInfoComponent],
  exports: [AppBarComponent],
  providers: [SharedService]
})
export class SharedModule {}
