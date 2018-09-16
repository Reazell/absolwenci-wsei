import { Component, OnInit, Input, AfterViewInit } from '@angular/core';

@Component({
  selector: 'app-survey-tile',
  templateUrl: './survey-tile.component.html',
  styleUrls: ['./survey-tile.component.scss']
})
export class SurveyTileComponent implements OnInit, AfterViewInit {
  @Input()
  survey;
  constructor() {}

  ngOnInit() {}
  ngAfterViewInit() {
    // console.log(this.survey);
  }
}
