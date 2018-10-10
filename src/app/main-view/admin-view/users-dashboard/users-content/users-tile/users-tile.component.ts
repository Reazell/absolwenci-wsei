import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { UnregisteredUser, UnregisteredUserModel } from './../../../../../models/user.model';

@Component({
  selector: 'app-users-tile',
  templateUrl: './users-tile.component.html',
  styleUrls: ['./users-tile.component.scss']
})
export class UsersTileComponent implements OnInit {
  @Input()
  user: UnregisteredUser;
  // @Output()
  // openCreator: EventEmitter<boolean> = new EventEmitter<boolean>();
  unregisteredUser: UnregisteredUserModel;
  // constructor(private surveyService: SurveyService) {}
  constructor() {}

  ngOnInit() {
    this.unregisteredUser = new UnregisteredUserModel(this.user);
  }
  openCreatorClick() {
    // this.surveyService.isCreatorLoading(true);
    // this.openCreator.emit(true);
  }
}
