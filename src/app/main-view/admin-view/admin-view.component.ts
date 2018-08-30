import { SharedService } from './../../services/shared.service';
import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';

@Component({
  selector: 'app-admin-view',
  templateUrl: './admin-view.component.html',
  styleUrls: ['./admin-view.component.scss']
})
export class AdminViewComponent implements OnInit, OnDestroy {
  show = true;
  showingMailView = false;
  isSidebarOpened = true;
  smallScreen: boolean;
  showDetails = false;
  toggleSidebarSubscription;
  @ViewChild('sidenav')
  sidenav;

  constructor(private sharedService: SharedService) {
    // this.isLargeScreen();
    // this.mailService.openModuleBool(true);
  }

  ngOnDestroy() {
    this.toggleSidebarSubscription.unsubscribe();
  }
  ngOnInit() {
    this.toggleSidebarSubscription = this.sharedService.toggleSidebar.subscribe(
      res => {
        if (this.sidenav) {
          this.sidenav.toggle();
        }
      }
    );
    // this.detailsService.showMailDetails.subscribe(res => {
    //   this.showDetails = res;
    //   this.showMailDetails();
    // });
  }
  isLargeScreen() {
    //   const width =
    //     window.innerWidth ||
    //     document.documentElement.clientWidth ||
    //     document.body.clientWidth;
    //   if (width > 1100) {
    //     if (this.smallScreen === undefined || this.smallScreen === true) {
    //       this.smallScreen = false;
    //       this.mailService.smallScreen.next(false);
    //     }
    //     return true;
    //   } else {
    //     if (this.isSidebarOpened === true) {
    //       this.isSidebarOpened = false;
    //     }
    //     if (width < 660) {
    //       if (this.smallScreen === undefined || this.smallScreen === false) {
    //         this.smallScreen = true;
    //         this.mailService.smallScreen.next(true);
    //       }
    //     } else {
    //       if (this.smallScreen === undefined || this.smallScreen === true) {
    //         this.smallScreen = false;
    //         this.mailService.smallScreen.next(false);
    //       }
    //     }
    //     return false;
    //   }
  }
  showMailDetails() {
    //   if (this.smallScreen === false) {
    //     this.showingMailView = true;
    //     return this.showingMailView;
    //   } else {
    //     if (this.showDetails === true) {
    //       this.showingMailView = true;
    //       return this.showingMailView;
    //     } else {
    //       this.showingMailView = false;
    //       return this.showingMailView;
    //     }
    //   }
  }
}
