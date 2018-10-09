import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-users-content',
  templateUrl: './users-content.component.html',
  styleUrls: ['./users-content.component.scss']
})
export class UsersContentComponent implements OnInit {
  groupTitle = 'Grupa użytkowników 1';
  buttonDets = 'Dodaj nowego użytkownika';

  constructor() {}

  ngOnInit() {}
}
