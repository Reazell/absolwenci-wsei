import {
  ChangeDetectionStrategy,
  Component,
  EventEmitter,
  Input,
  Output,
  ViewChild
} from '@angular/core';
import { MatMenuTrigger } from '../../../../node_modules/@angular/material';
import { AppBarTooltip } from '../../shared/models/shared.models';

@Component({
  selector: 'app-bar',
  templateUrl: './app-bar.component.html',
  styleUrls: ['./app-bar.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AppBarComponent {
  @ViewChild(MatMenuTrigger)
  trigger: MatMenuTrigger;

  private _showAdmin: boolean;
  private _showSendButton: boolean;
  private _showToggleButton: boolean;
  private _isLogged: boolean;
  private _accountRole: string;
  private _showCreatorButton: boolean;
  private _showAdminMenu: boolean;
  private _showBackButton: boolean;
  private _showUserInfo: boolean;

  // inputs
  @Input()
  toolTipInfo: AppBarTooltip;
  @Input()
  logoIMG: string;
  @Input()
  profileIMG: string;

  // get set inputs

  @Input()
  set isLogged(isLogged) {
    this._isLogged = isLogged;
  }
  get isLogged() {
    return this._isLogged;
  }

  @Input()
  set accountRole(accountRole) {
    this._accountRole = accountRole;
  }
  get accountRole() {
    return this._accountRole;
  }

  @Input()
  set showCreatorButton(showCreatorButton) {
    this._showCreatorButton = showCreatorButton;
  }
  get showCreatorButton() {
    return this._showCreatorButton;
  }

  @Input()
  set showSendButton(showSendButton) {
    this._showSendButton = showSendButton;
  }
  get showSendButton() {
    return this._showSendButton;
  }

  @Input()
  set showAdminMenu(showAdminMenu) {
    this._showAdminMenu = showAdminMenu;
  }
  get showAdminMenu() {
    return this._showAdminMenu;
  }

  @Input()
  set showToggleButton(showToggleButton) {
    this._showToggleButton = showToggleButton;
  }
  get showToggleButton() {
    return this._showToggleButton;
  }

  @Input()
  set showBackButton(showBackButton) {
    this._showBackButton = showBackButton;
  }
  get showBackButton() {
    return this._showBackButton;
  }

  @Input()
  set showUserInfo(showUserInfo) {
    this._showUserInfo = showUserInfo;
  }
  get showUserInfo() {
    return this._showUserInfo;
  }

  @Input()
  set showAdmin(showAdmin) {
    this._showAdmin = showAdmin;
  }
  get showAdmin() {
    return this._showAdmin;
  }

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
  // @Output()

  // child outputs
  @Output()
  logout: EventEmitter<boolean> = new EventEmitter<boolean>();
  @Output()
  routeSwitch: EventEmitter<boolean> = new EventEmitter<boolean>();

  constructor() {}

  // emit button actions
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

  // emit child actions

  emitLogout() {
    this.logout.emit(true);
  }
  emitRouteSwitch() {
    this.routeSwitch.emit(true);
  }

  // actions

  openHoveredMenu() {
    this.trigger.openMenu();
  }
  closeHoveredMenu() {
    this.trigger.closeMenu();
  }
}