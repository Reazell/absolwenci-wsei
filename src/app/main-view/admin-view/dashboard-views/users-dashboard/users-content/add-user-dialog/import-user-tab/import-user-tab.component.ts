import {
  Component,
  ElementRef,
  OnInit,
  ViewChild,
  ViewChildren
} from '@angular/core';
import { FileUpload } from '../../../../../../../../../node_modules/primeng/fileupload';
import {
  UnregisteredUser,
  UnregisteredUserModel
} from '../../../../../../../models/user.model';
import { UserService } from './../../../../../survey-container/services/user.services';

@Component({
  selector: 'app-import-user-tab',
  templateUrl: './import-user-tab.component.html',
  styleUrls: ['./import-user-tab.component.scss']
})
export class ImportUserTabComponent implements OnInit {
  @ViewChild('fileInput')
  fileInput: FileUpload;
  @ViewChildren('progress')
  progress: ElementRef;
  attachmentsLength = 0;

  constructor(private userService: UserService) {}

  ngOnInit() {}

  removeAttachment(event, i) {
    this.fileInput.remove(event, i);
    this.attachmentsLength = this.fileInput.files.length;
  }
  formatSize(bytes) {
    return this.fileInput.formatSize(bytes);
  }
  uploadFiles(fileObj) {
    console.log(fileObj);
    const files = fileObj.files;
    const body = new FormData();
    // files.forEach(file => {
    //   body.append('File', file);
    // });
    // tslint:disable-next-line:prefer-for-of
    for (let i = 0; i < files.length; i++) {
      const ff = files[i];
      body.append('File', ff);
    }
    console.log(body);
    this.userService.importUsers(body).subscribe(
      data => {
        console.log(data);
      },
      error => {
        console.log(error);
      }
    );
  }
  onFileSelect(event) {
    const progress = this.progress['_results'];
    const filesLength = this.fileInput.files.length;
    let value: number;
    // Reset progress indicator on new file selection.
    for (let i = this.attachmentsLength; i < filesLength; i++) {
      const reader: FileReader = new FileReader();
      reader.readAsDataURL(this.fileInput.files[i]);
      reader.onabort = () => {
        alert('File read cancelled');
      };
      reader.onprogress = e => {
        if (e.lengthComputable) {
          value = Math.round((e.loaded * 100) / e.total);
          progress[i].nativeElement.style.width = value + '%';
        }
      };
    }
    this.attachmentsLength = filesLength;
    this.fileInput.onFileSelect(event);
  }
}
