import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-survey-content',
  templateUrl: './survey-content.component.html',
  styleUrls: ['./survey-content.component.scss']
})
export class SurveyContentComponent implements OnInit {
  groupTitle = 'Grupa ankiet 1';
  buttonDets = 'Stwórz nową ankietę';
  constructor() {}

  ngOnInit() {}
}
