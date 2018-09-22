import { Component, OnInit } from '@angular/core';
import { SharedService } from './../../../../services/shared.service';

@Component({
  selector: 'app-survey-container',
  templateUrl: './survey-container.component.html',
  styleUrls: ['./survey-container.component.scss']
})
export class SurveyContainerComponent implements OnInit {
  constructor(private sharedService: SharedService) {}

  ngOnInit() {
    this.showAdminMenu();
    this.showUserInfo();
  }
  showAdminMenu() {
    this.sharedService.showAdminMain(false);
  }
  showUserInfo() {
    this.sharedService.showUser(false);
  }
}
