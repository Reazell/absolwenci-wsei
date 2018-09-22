import { Component, OnInit } from '@angular/core';
import { SharedService } from './../services/shared.service';

@Component({
  selector: 'app-main-view',
  templateUrl: './main-view.component.html',
  styleUrls: ['./main-view.component.scss']
})
export class MainViewComponent implements OnInit {
  constructor(private sharedService: SharedService) {}

  ngOnInit() {
    this.showUserInfo();
  }
  showUserInfo() {
    this.sharedService.showUser(true);
  }
}
