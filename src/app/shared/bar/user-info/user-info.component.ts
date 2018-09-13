import { AuthenticationService } from './../../../auth/services/authentication.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.scss']
})
export class UserInfoComponent implements OnInit {
  constructor(private authenticationService: AuthenticationService) {}

  ngOnInit() {
  }

  toggleMenu() {
    // this.trigger.openMenu();
  }

  logout() {
    this.toggleMenu();
    this.authenticationService.logout();
  }
}
