import { PoolingService } from './../../../services/pooling.services';
import { Component, OnInit } from '@angular/core';
import {
  FormGroup,
  AbstractControl,
  FormBuilder,
  Validators
} from '@angular/forms';

@Component({
  selector: 'app-pooling-write',
  templateUrl: './pooling-write.component.html',
  styleUrls: ['./pooling-write.component.scss']
})
export class PoolingWriteComponent implements OnInit {
  sentForm: FormGroup;
  text: AbstractControl;

  constructor(
    private fb: FormBuilder,
    private poolingService: PoolingService
  ) {}

  ngOnInit() {
    this.sentForm = this.fb.group({
      text: ['', Validators.required]
    });
    this.text = this.sentForm.controls['text'];
  }
  onSubmit() {
    this.poolingService.sendPooling(this.text.value).subscribe(
      data => {
        console.log(data);
      },
      error => {
        console.log(error);
      }
    );
  }
}
