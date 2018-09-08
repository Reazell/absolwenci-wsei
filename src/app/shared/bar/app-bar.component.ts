import { Component, OnInit, OnDestroy } from '@angular/core';
import { SharedService } from '../../services/shared.service';
import { UserService } from '../../auth/services/user.service';

@Component({
  selector: 'app-bar',
  templateUrl: './app-bar.component.html',
  styleUrls: ['./app-bar.component.scss']
})
export class AppBarComponent implements OnInit, OnDestroy {
  userServiceSub;
  isLogged = false;
  constructor(
    private sharedService: SharedService,
    private userService: UserService
  ) {}

  ngOnInit() {
    this.userService.isLogged.subscribe(data => {
      console.log(data);
      this.isLogged = data;
    });
  }

  openSidebar() {
    this.sharedService.toggleSideNav();
  }
  ngOnDestroy() {
    this.userServiceSub.unsubscribe();
  }
}
