import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-add-user-tab',
  templateUrl: './add-user-tab.component.html',
  styleUrls: ['./add-user-tab.component.scss']
})
export class AddUserTabComponent implements OnInit {
  @Input()
  dialogForm: FormGroup;
  @Input()
  loader: boolean;
  @Output()
  submit: EventEmitter<FormGroup> = new EventEmitter<FormGroup>();
  constructor() {}

  ngOnInit() {}
  onSubmit(dialog) {
    this.submit.emit(dialog);
  }
}
