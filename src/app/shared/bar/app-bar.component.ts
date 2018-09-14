import { Component, OnDestroy, OnInit, HostListener } from '@angular/core';
import { SharedService } from '../../services/shared.service';
import { UserService } from '../../auth/services/user.service';

@Component({
  selector: 'app-bar',
  templateUrl: './app-bar.component.html',
  styleUrls: ['./app-bar.component.scss']
})
export class AppBarComponent implements OnInit, OnDestroy {
  userServiceSub;
  isLogged: boolean;
  sticky;

  constructor(
    private sharedService: SharedService,
    private userService: UserService
  ) {}

  ngOnInit() {
    this.userService.isLogged.subscribe(data => {
      this.isLogged = data;
    });
  }
  // stickyNav(nav) {
  //   console.log('sth');


  openSidebar() {
    this.sharedService.toggleSideNav();
  }
  ngOnDestroy() {
    this.userServiceSub.unsubscribe();
  }
}
