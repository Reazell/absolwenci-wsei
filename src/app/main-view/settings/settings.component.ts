import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { SharedService } from '../../services/shared.service';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
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
    companyName: 'WSEI',
    location: 'Kraków',
    companyDescription: ''
  };

  constructor(private sharedService: SharedService) {}

  ngOnInit() {
    this.backButton();
  }
  backButton() {
    this.sharedService.showBackButton(true);
  }
}
