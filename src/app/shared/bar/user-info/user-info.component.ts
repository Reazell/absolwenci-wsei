import { Component, Input, OnInit } from '@angular/core';
import { AuthenticationService } from '../../../auth/services/authentication.service';
import { SharedService } from '../../../services/shared.service';

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.scss']
})
export class UserInfoComponent implements OnInit {
  profileType: string;

  constructor(
    private authenticationService: AuthenticationService,
    private sharedService: SharedService
  ) {}

  ngOnInit() {
    this.profileType = JSON.parse(localStorage.getItem('currentUser')).role;
  }

  logout() {
    this.authenticationService.logout();
  }

  routeSwitch(role) {
    this.sharedService.routeSwitch(role);
  }
}
