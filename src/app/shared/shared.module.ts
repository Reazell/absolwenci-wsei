import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { AppBarComponent } from './bar/app-bar.component';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialsModule } from '../materials/materials.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedService } from '../services/shared.service';
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
