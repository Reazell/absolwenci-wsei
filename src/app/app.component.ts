import { Component, OnInit } from '@angular/core';
import {
  NavigationCancel,
  NavigationEnd,
  NavigationError,
  NavigationStart,
  Router,
  RouterEvent
} from '@angular/router';
import { BehaviorSubject, Observable, Subject, Subscription } from 'rxjs';
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
  creatorSub: Subscription = new Subscription();
  sendSub: Subscription = new Subscription();
  adminMainSub: Subscription = new Subscription();
  toggleSub: Subscription = new Subscription();
  backSub: Subscription = new Subscription();
  accountRoleSub: Subscription = new Subscription();
  userInfoSub: Subscription = new Subscription();

  // subjects
  private _showAdminMenu$: BehaviorSubject<boolean> = new BehaviorSubject<
    boolean
  >(false);
  get showAdminMenu$(): Observable<boolean> {
    return this._showAdminMenu$.asObservable();
  }

  private _isLogged$: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(
    false
  );
  get isLogged$(): Observable<boolean> {
    return this._isLogged$.asObservable();
  }

  private _showToggleButton$: BehaviorSubject<boolean> = new BehaviorSubject<
    boolean
  >(false);
  get showToggleButton$(): Observable<boolean> {
    return this._showToggleButton$.asObservable();
  }

  private _showUserInfo$: BehaviorSubject<boolean> = new BehaviorSubject<
    boolean
  >(false);
  get showUserInfo$(): Observable<boolean> {
    return this._showUserInfo$.asObservable();
  }

  private _showBackButton$: BehaviorSubject<boolean> = new BehaviorSubject<
    boolean
  >(false);
  get showBackButton$(): Observable<boolean> {
    return this._showBackButton$.asObservable();
  }

  private _showSendButton$: BehaviorSubject<boolean> = new BehaviorSubject<
    boolean
  >(false);
  get showSendButton$(): Observable<boolean> {
    return this._showSendButton$.asObservable();
  }

  private _showCreatorButton$: BehaviorSubject<boolean> = new BehaviorSubject<
    boolean
  >(false);
  get showCreatorButton$(): Observable<boolean> {
    return this._showCreatorButton$.asObservable();
  }

  private _accountRole$: BehaviorSubject<string> = new BehaviorSubject<string>(
    undefined
  );
  get accountRole$(): Observable<string> {
    return this._accountRole$.asObservable();
  }

  // inputs
  loading: boolean;
  logoIMG = './../../../assets/logo-wsei.png';
  profileIMG = './../../../assets/profile-image.png';
  // isLogged = false;
  showCreatorButton = false;
  showSendButton = false;
  showAdminMenu = false;
  showToggleButton = false;
  showBackButton = false;
  showUserInfo = false;
  // accountRole: string;
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
    this.loggedAccountRole();
    this.checkIfLogged();
    this.showUser();
    this.showCreator();
    this.showSend();
    this.showingAdminMenu();
    this.showToggle();
    this.showBack();
  }

  // showing bar buttons

  loggedAccountRole(): void {
    this.accountRoleSub = this.accountService.role.subscribe(role => {
      // this.accountRole = role;
      console.log(role);
      Promise.resolve(null).then(() => this._accountRole$.next(role));
    });
  }
  checkIfLogged(): void {
    this.userServiceSub = this.accountService.isLogged.subscribe(data => {
      Promise.resolve(null).then(() => this._isLogged$.next(data));
    });
  }
  // showing elements
  showUser(): void {
    this.userInfoSub = this.sharedService.showUserInfo.subscribe(data => {
      Promise.resolve(null).then(() => this._showUserInfo$.next(data));
    });
  }
  showToggle(): void {
    this.toggleSub = this.sharedService.showToggle.subscribe(data => {
      Promise.resolve(null).then(() => this._showToggleButton$.next(data));
    });
  }
  showCreator(): void {
    this.creatorSub = this.sharedService.showCreator.subscribe(data => {
      Promise.resolve(null).then(() => this._showCreatorButton$.next(data));
    });
  }
  showSend(): void {
    this.sendSub = this.sharedService.showSend.subscribe(data => {
      Promise.resolve(null).then(() => this._showSendButton$.next(data));
    });
  }
  showingAdminMenu(): void {
    this.adminMainSub = this.sharedService.showAdminMenu.subscribe(data => {
      Promise.resolve(null).then(() => this._showAdminMenu$.next(data));
    });
  }
  showBack(): void {
    this.backSub = this.sharedService.showBack.subscribe(data => {
      Promise.resolve(null).then(() => this._showBackButton$.next(data));
    });
  }

  editSurvey(): void {
    this.sharedService.routeToEdit(true);
  }
  sendSurvey(): void {
    this.sharedService.showSendSurveyDialog(true);
  }
  showSurvey(): void {
    this.sharedService.showSurveyButton(true);
  }
  openSidebar(): void {
    this.sharedService.toggleSideNav(true);
  }

  redirectTo(data: string): void {
    const url = '/app/admin/d/' + data;
    this.router.navigateByUrl(url);
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
}
