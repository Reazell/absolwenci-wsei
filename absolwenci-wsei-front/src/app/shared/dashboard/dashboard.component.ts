import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Subscription } from 'rxjs/Subscription';
import { SharedService } from '../../services/shared.service';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit, OnDestroy {
  @ViewChild(RouterOutlet)
  outlet: RouterOutlet;
  show = true;
  loading = true;
  showingMailView = false;
  smallScreen: boolean;
  showDetails = false;

  // subs
  outletDeactivateSub: Subscription = new Subscription();

  constructor(private sharedService: SharedService) {}
  ngOnInit(): void {
    this.showUserInfo();
    this.showToggleButton(true);
  }
  showUserInfo(): void {
    this.sharedService.showUser(true);
  }
  showToggleButton(x: boolean): void {
    this.sharedService.showToggleButton(x);
  }
  showAdminMenu(): void {
    this.sharedService.showAdminMain(true);
  }
  setLoader(): void {
    this.loading = false;
  }
  ngOnDestroy(): void {
    // this.showToggleButton(false);
  }
}
