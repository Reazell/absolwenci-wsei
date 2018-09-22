import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { Subscription } from 'rxjs/Subscription';
import { SharedService } from '../../../../services/shared.service';

@Component({
  selector: 'app-survey-dashboard',
  templateUrl: './survey-dashboard.component.html',
  styleUrls: ['./survey-dashboard.component.scss']
})
export class SurveyDashboardComponent implements OnInit, OnDestroy {
  @ViewChild('sidenav')
  sidenav;
  show = true;
  loading = true;
  showingMailView = false;
  isSidebarOpened = true;
  smallScreen: boolean;
  showDetails = false;
  // subs
  toggleSidebarSub: Subscription;

  constructor(private sharedService: SharedService) {
    // this.isLargeScreen();
    // this.mailService.openModuleBool(true);
  }
  ngOnInit(): void {
    this.showUserInfo();
    this.showToggleButton();
    // this.toggleSidebar();
  }
  toggleSidebar(): void {
    this.toggleSidebarSub = this.sharedService.toggleSidebar.subscribe(res => {
      if (this.sidenav) {
        this.sidenav.toggle();
      }
    });
  }
  showUserInfo(): void {
    this.sharedService.showUser(true);
  }
  showToggleButton() {
    this.sharedService.showToggleButton(true);
  }
  showAdminMenu(): void {
    this.sharedService.showAdminMain(true);
  }
  isLargeScreen(): boolean {
    const width =
      window.innerWidth ||
      document.documentElement.clientWidth ||
      document.body.clientWidth;
    if (width < 1100) {
      if (this.isSidebarOpened === true) {
        this.isSidebarOpened = false;
      }
      return false;
    } else {
      if (this.isSidebarOpened === false) {
        this.isSidebarOpened = true;
      }
      return true;
    }
  }
  showMailDetails(): void {
    // if (this.smallScreen === false) {
    //   this.showingMailView = true;
    //   return this.showingMailView;
    // } else {
    //   if (this.showDetails === true) {
    //     this.showingMailView = true;
    //     return this.showingMailView;
    //   } else {
    //     this.showingMailView = false;
    //     return this.showingMailView;
    //   }
    // }
  }
  setLoader() {
    this.loading = false;
  }
  ngOnDestroy() {
    // this.toggleSidebarSub.unsubscribe();
  }
}
