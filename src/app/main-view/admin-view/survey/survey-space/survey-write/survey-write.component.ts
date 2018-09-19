import { Component, OnInit } from '@angular/core';
import {
  FormGroup,
  AbstractControl,
  FormBuilder,
  Validators
} from '@angular/forms';
import { SurveyService } from '../../../../services/survey.services';

@Component({
  selector: 'app-survey-write',
  templateUrl: './survey-write.component.html',
  styleUrls: ['./survey-write.component.scss']
})
export class SurveyWriteComponent implements OnInit {
  sentForm: FormGroup;
  text: AbstractControl;

  constructor(private fb: FormBuilder, private surveyService: SurveyService) {}

  ngOnInit() {
    this.sentForm = this.fb.group({
      text: ['', Validators.required]
    });
    this.text = this.sentForm.controls['text'];
  }
  onSubmit() {
    this.surveyService.sendSurvey(this.text.value).subscribe(
      data => {
        console.log(data);
      },
      error => {
        console.log(error);
      }
    );
  }
}
