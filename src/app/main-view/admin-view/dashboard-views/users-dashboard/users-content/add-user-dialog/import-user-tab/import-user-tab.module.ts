import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { FileUploadModule } from 'primeng/fileupload';
import { MatButtonModule } from '../../../../../../../../../node_modules/@angular/material';
import { ImportUserTabComponent } from './import-user-tab.component';

@NgModule({
  imports: [
    CommonModule,
    FileUploadModule,
    FontAwesomeModule,
    MatButtonModule,
    MatProgressSpinnerModule,
  ],
  declarations: [ImportUserTabComponent]
})
export class ImportUserTabModule {}
