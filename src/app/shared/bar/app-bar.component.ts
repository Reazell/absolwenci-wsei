import {
  ChangeDetectionStrategy,
  Component,
  EventEmitter,
  Input,
  OnInit,
  Output
} from '@angular/core';
import { AppBarTooltip } from '../models/shared.models';

@Component({
  selector: 'app-bar',
  templateUrl: './app-bar.component.html',
  styleUrls: ['./app-bar.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AppBarComponent {
  // inputs
  @Input()
  toolTipInfo: AppBarTooltip;
  @Input()
  isLogged: boolean;
  @Input()
  accountRole: string;
  @Input()
  wseiIMG: string;
  @Input()
  profileIMG: string;
  @Input()
  _showCreatorButton: boolean;
  @Input()
  _showSendButton: boolean;
  @Input()
  _showAdminMenu: boolean;
  @Input()
  _showToggleButton: boolean;
  @Input()
  _showBackButton: boolean;
  @Input()
  _showUserInfo: boolean;

  // outputs
  @Output()
  showSurveyButton: EventEmitter<boolean> = new EventEmitter<boolean>();
  @Output()
  editSurveyButton: EventEmitter<boolean> = new EventEmitter<boolean>();
  @Output()
  openSidebarButton: EventEmitter<boolean> = new EventEmitter<boolean>();
  @Output()
  redirectToButton: EventEmitter<string> = new EventEmitter<string>();
  @Output()
  sendSurveyDialog: EventEmitter<boolean> = new EventEmitter<boolean>();

  constructor() {}

  redirectTo(data: string): void {
    this.redirectToButton.emit(data);
  }
  showSurvey(): void {
    this.showSurveyButton.emit(true);
  }
  sendSurvey(): void {
    this.sendSurveyDialog.emit(true);
  }
  editSurvey(): void {
    this.editSurveyButton.emit(true);
  }
  openSidebar(): void {
    this.openSidebarButton.emit(true);
  }
}

// import { Component, OnDestroy, OnInit } from '@angular/core';
// import { Router } from '@angular/router';
// import { Subscription } from 'rxjs/Subscription';
// import { AccountService } from '../../auth/services/account.service';
// import { SharedService } from '../../services/shared.service';

// @Component({
//   selector: 'app-bar',
//   templateUrl: './app-bar.component.html',
//   styleUrls: ['./app-bar.component.scss']
// })
// export class AppBarComponent implements OnInit, OnDestroy {
//   // subs
//   userServiceSub: Subscription = new Subscription();
//   creatorSub: Subscription = new Subscription();
//   sendSub: Subscription = new Subscription();
//   adminMainSub: Subscription = new Subscription();
//   toggleSub: Subscription = new Subscription();
//   backSub: Subscription = new Subscription();
//   accountRoleSub: Subscription = new Subscription();
//   userInfoSub: Subscription = new Subscription();

//   isLogged = false;
//   showCreatorButton = false;
//   showSendButton = false;
//   showAdminMenu = false;
//   showToogleButton = false;
//   showBackButton = false;
//   showUserInfo = false;
//   accountRole: string;

//   info = {
//     show: 'Podgląd',
//     edit: 'Edytuj ankietę',
//     main: 'Strona główna ankiet'
//   };

//   constructor(
//     private sharedService: SharedService,
//     private accountService: AccountService,
//     private router: Router
//   ) {}

//   ngOnInit() {
//     this.loggedAccountRole();
//     this.checkIfLogged();
//     this.showUser();
//     this.showCreator();
//     this.showSend();
//     this.showingAdminMenu();
//     this.showToogle();
//     this.showBack();
//   }

//   loggedAccountRole(): void {
//     this.accountRoleSub = this.accountService.role.subscribe(role => {
//       this.accountRole = role;
//     });
//   }
//   checkIfLogged(): void {
//     this.userServiceSub = this.accountService.isLogged.subscribe(data => {
//       this.isLogged = data;
//     });
//   }
//   // showing elements
//   showUser(): void {
//     this.userInfoSub = this.sharedService.showUserInfo.subscribe(data => {
//       // console.log('f', data);
//       this.showUserInfo = data;
//     });
//   }
//   showToogle(): void {
//     this.toggleSub = this.sharedService.showToggle.subscribe(data => {
//       this.showToogleButton = data;
//     });
//   }
//   showCreator(): void {
//     this.creatorSub = this.sharedService.showCreator.subscribe(data => {
//       this.showCreatorButton = data;
//     });
//   }
//   showSend(): void {
//     this.sendSub = this.sharedService.showSend.subscribe(data => {
//       this.showSendButton = data;
//     });
//   }
//   showingAdminMenu(): void {
//     this.adminMainSub = this.sharedService.showAdminMenu.subscribe(data => {
//       this.showAdminMenu = data;
//     });
//   }
//   showBack(): void {
//     this.backSub = this.sharedService.showBack.subscribe(data => {
//       this.showBackButton = data;
//     });
//   }

//   // button actions
//   editSurvey(): void {
//     this.sharedService.routeToEdit(true);
//   }
//   sendSurvey(): void {
//     this.sharedService.showSendSurveyDialog(true);
//   }
//   showSurvey(): void {
//     this.sharedService.showSurveyButton(true);
//   }
//   openSidebar(): void {
//     this.sharedService.toggleSideNav(true);
//   }

//   redirectTo(data: string): void {
//     const url = '/app/admin/d/' + data;
//     this.router.navigateByUrl(url);
//   }
//   ngOnDestroy(): void {
//     this.userServiceSub.unsubscribe();
//     this.creatorSub.unsubscribe();
//     this.sendSub.unsubscribe();
//     this.adminMainSub.unsubscribe();
//   }
// }

