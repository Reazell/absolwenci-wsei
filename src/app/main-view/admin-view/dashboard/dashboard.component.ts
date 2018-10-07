import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Subscription } from 'rxjs/Subscription';
import { SharedService } from '../../../services/shared.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit, OnDestroy {
  @ViewChild('sidenav')
  sidenav;
  @ViewChild(RouterOutlet)
  outlet: RouterOutlet;
  show = true;
  loading = true;
  showingMailView = false;
  isSidebarOpened = true;
  smallScreen: boolean;
  showDetails = false;

  // subs
  toggleSidebarSub: Subscription = new Subscription();
  outletDeactivateSub: Subscription = new Subscription();

  constructor(private sharedService: SharedService) {}
  ngOnInit(): void {
    this.showUserInfo();
    this.showToggleButton();
    this.toggleSidebar();
  }
  toggleSidebar(): void {
    this.toggleSidebarSub = this.sharedService.toggleSidebar.subscribe(() => {
      if (this.sidenav) {
        this.sidenav.toggle();
      }
    });
  }
  showUserInfo(): void {
    this.sharedService.showUser(true);
  }
  showToggleButton(): void {
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
  setLoader() {
    this.loading = false;
  }
  ngOnDestroy() {
    this.toggleSidebarSub.unsubscribe();
  }
}
