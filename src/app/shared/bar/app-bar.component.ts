import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs/Subscription';
import { UserService } from '../../auth/services/user.service';
import { SharedService } from '../../services/shared.service';

@Component({
  selector: 'app-bar',
  templateUrl: './app-bar.component.html',
  styleUrls: ['./app-bar.component.scss']
})
export class AppBarComponent implements OnInit, OnDestroy {
  // subs
  userServiceSub: Subscription;
  creatorSub: Subscription;
  sendSub: Subscription;
  surveyMainSub: Subscription;
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
    this.sharedService.routeToEdit(true);
  }
  sendSurvey() {
    this.sharedService.showSendSurveyDialog(true);
  }
  showSurvey() {
    this.sharedService.showSurveyButton(true);
  }
  saveSurvey() {
    this.sharedService.saveSurveyButton(true);
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
