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

  isLogged: boolean;
  showCreatorMenu = false;

  constructor(
    private sharedService: SharedService,
    private userService: UserService
  ) {}

  ngOnInit() {
    this.checkIfLogged();
    this.openCreator();
  }

  checkIfLogged() {
    this.userServiceSub = this.userService.isLogged.subscribe(data => {
      this.isLogged = data;
    });
  }
  openCreator() {
    this.creatorSub = this.sharedService.openCreator.subscribe(data => {
      this.showCreatorMenu = data;
    });
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
  }
}
