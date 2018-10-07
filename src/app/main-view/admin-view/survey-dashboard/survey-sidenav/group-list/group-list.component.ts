import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-group-list',
  templateUrl: './group-list.component.html',
  styleUrls: ['./group-list.component.scss']
})
export class GroupListComponent implements OnInit {
  groupList = [
    {
      name: 'studenci'
    },
    {
      name: 'pracodawcy'
    },
    {
      name: 'absolwenci'
    }
  ];

  constructor() {}

  ngOnInit() {}
}
