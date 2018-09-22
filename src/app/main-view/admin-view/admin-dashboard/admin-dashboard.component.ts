import { Component, OnInit } from '@angular/core';
import { SharedService } from '../../../services/shared.service';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.scss']
})
export class AdminDashboardComponent implements OnInit {
  constructor(private sharedService: SharedService) {}

  ngOnInit() {
    this.showUserInfo();
  }
  showUserInfo() {
    this.sharedService.showUser(true);
  }
}
