import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-survey-sidenav',
  templateUrl: './survey-sidenav.component.html',
  styleUrls: ['./survey-sidenav.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SurveySidenavComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
