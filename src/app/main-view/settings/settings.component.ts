import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.scss']
})
export class SettingsComponent implements OnInit {
  userInfo = {
    id: 2,
    name: 'Gabriela',
    surname: 'Oskroba',
    email: 'gabi97_97@o2.pl',
    phoneNum: '+48123123123',
    albumID: '10610',
    degree: 'IT',
    major: 'gamedev',
    mode: 'extramural',
    year: 3,
    initialSemester: 'winter',
    companyName: 'QVC',
    location: 'Kraków',
    companyDescription: ''
  };

  constructor() {}

  ngOnInit() {}
}
