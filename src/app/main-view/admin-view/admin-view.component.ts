import { SharedService } from '../../services/shared.service';
import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';

@Component({
  selector: 'app-admin-view',
  templateUrl: './admin-view.component.html',
  styleUrls: ['./admin-view.component.scss']
})
export class AdminViewComponent implements OnInit, OnDestroy {
  @ViewChild('sidenav')
  sidenav;
  show = true;
  showingMailView = false;
  isSidebarOpened = true;
  smallScreen: boolean;
  showDetails = false;
  // subs
  toggleSidebarSub;

  constructor(private sharedService: SharedService) {
    // this.isLargeScreen();
    // this.mailService.openModuleBool(true);
  }

  ngOnInit() {
    this.toggleSidebar();
    this.showSurveyMain();
  }
  toggleSidebar() {
    this.toggleSidebarSub = this.sharedService.toggleSidebar.subscribe(res => {
      if (this.sidenav) {
        this.sidenav.toggle();
      }
    });
  }
  showSurveyMain() {
    this.sharedService.showSurveyMain(true);
  }

  isLargeScreen() {
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
  showMailDetails() {
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
  ngOnDestroy() {
    this.toggleSidebarSub.unsubscribe();
  }
}
