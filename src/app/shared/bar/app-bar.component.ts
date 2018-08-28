import { Component, OnInit } from '@angular/core';
import { SharedService } from '../../services/shared.service';

@Component({
  selector: 'app-bar',
  templateUrl: './app-bar.component.html',
  styleUrls: ['./app-bar.component.scss']
})
export class AppBarComponent implements OnInit {
  constructor(private sharedService: SharedService) {}

  ngOnInit() {}

  openSidebar() {
    this.sharedService.toggleSideNav();
  }
}
