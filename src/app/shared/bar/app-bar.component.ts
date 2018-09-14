import { Component, OnDestroy, OnInit } from '@angular/core';
import { SharedService } from '../../services/shared.service';
import { UserService } from '../../auth/services/user.service';

@Component({
  selector: 'app-bar',
  templateUrl: './app-bar.component.html',
  styleUrls: ['./app-bar.component.scss']
})
export class AppBarComponent implements OnInit, OnDestroy {
  // subs
  userServiceSub;
  creatorSub;
  sendSub;
  surveyMainSub;

  isLogged: boolean;
  showCreatorButton = false;
  showSendButton = false;
  showSurveyMenu = false;
  constructor(
    private sharedService: SharedService,
    private userService: UserService
  ) {}

  ngOnInit() {
    this.checkIfLogged();
    this.showCreator();
    this.showSend();
    this.showMenu();
  }

  checkIfLogged() {
    this.userServiceSub = this.userService.isLogged.subscribe(data => {
      this.isLogged = data;
    });
  }
  showCreator() {
    this.creatorSub = this.sharedService.showCreator.subscribe(data => {
      this.showCreatorButton = data;
    });
  }
  showSend() {
    this.sendSub = this.sharedService.showSend.subscribe(data => {
      this.showSendButton = data;
    });
  }
  showMenu() {
    this.surveyMainSub = this.sharedService.showSurveyMenu.subscribe(data => {
      this.showSurveyMenu = data;
    });
  }

  saveSurvey() {
    this.sharedService.saveSurveyButton(0);
  }
  sendSurvey() {
    this.sharedService.sendSurveyButton(0);
  }
  openSidebar() {
    this.sharedService.toggleSideNav();
  }
  ngOnDestroy() {
    this.userServiceSub.unsubscribe();
    this.creatorSub.unsubscribe();
    this.sendSub.unsubscribe();
    this.surveyMainSub.unsubscribe();
  }
}
