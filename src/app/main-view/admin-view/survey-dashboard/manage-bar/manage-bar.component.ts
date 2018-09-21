import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-manage-bar',
  templateUrl: './manage-bar.component.html',
  styleUrls: ['./manage-bar.component.scss']
})
export class ManageBarComponent implements OnInit {
  constructor(private router: Router) {}

  ngOnInit() {}
}
