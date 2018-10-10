import { Component, OnInit } from '@angular/core';
import {
  NavigationCancel,
  NavigationEnd,
  NavigationError,
  NavigationStart,
  Router,
  RouterEvent
} from '@angular/router';
import { Subscription } from 'rxjs';
import { AccountService } from './auth/services/account.service';
import { SharedService } from './services/shared.service';
import { AppBarTooltip } from './shared/models/shared.models';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  // subs
  userServiceSub: Subscription = new Subscription();
  accountRoleSub: Subscription = new Subscription();

  // inputs
  loading: boolean;
  wseiIMG = './../../../assets/logo-wsei.png';
  profileIMG = './../../../assets/profile-image.png';
  isLogged = false;
  showBackButton = false;
  accountRole: string;
  toolTipInfo: AppBarTooltip = new AppBarTooltip();

  constructor(
    private router: Router,
    private accountService: AccountService,
    private sharedService: SharedService
  ) {
    this.router.events.subscribe((event: RouterEvent) => {
      this.navigationInterceptor(event);
    });
  }
  ngOnInit() {
    this.checkIfLogged();
    this.loggedAccountRole();
  }

  // showing bar buttons

  // showBack(): void {
  //   this.backSub = this.sharedService.showBack.subscribe(data => {
  //     this.showBackButton = data;
  //   });
  // }

  // actions
  checkIfLogged(): void {
    this.userServiceSub = this.accountService.isLogged.subscribe(data => {
      this.isLogged = data;
    });
  }
  loggedAccountRole(): void {
    this.accountRoleSub = this.accountService.role.subscribe(role => {
      this.accountRole = role;
    });
  }
  editSurvey(): void {
    this.sharedService.routeToEdit(true);
  }
  openSidebar(): void {
    this.sharedService.toggleSideNav(true);
  }
  redirectTo(data: string): void {
    const url = '/app/admin/d/' + data;
    this.router.navigateByUrl(url);
  }
  sendSurvey(): void {
    this.sharedService.showSendSurveyDialog(true);
  }

  navigationInterceptor(event: RouterEvent): void {
    if (event instanceof NavigationStart) {
      this.loading = true;
    } else if (
      event instanceof NavigationEnd ||
      event instanceof NavigationCancel ||
      event instanceof NavigationError
    ) {
      this.loading = false;
    }
  }
  showSurvey() {}
}
