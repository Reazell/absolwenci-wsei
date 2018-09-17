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
  // editSurveySub;

  isLogged: boolean;
  showCreatorButton = false;
  showSendButton = false;
  showSurveyMenu = false;

  info = {
    show: 'Podgląd',
    edit: 'Edytuj ankietę',
    save: 'Zapisz ankietę'
  };

  constructor(
    private sharedService: SharedService,
    private userService: UserService
  ) {}

  ngOnInit() {
    this.showCreator();
    this.showSend();
    this.showMenu();
    this.checkIfLogged();
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
  editSurvey() {
    this.sharedService.routeToEdit(0);
  }
  sendSurvey() {
    this.sharedService.showSendSurveyDialog(0);
  }
  showSurvey() {
    this.sharedService.showSurveyButton(0);
  }
  saveSurvey() {
    this.sharedService.saveSurveyButton(0);
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
