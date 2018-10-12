import {
  ChangeDetectionStrategy,
  Component,
  EventEmitter,
  Output
} from '@angular/core';

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class UserInfoComponent {
  @Output()
  logout: EventEmitter<boolean> = new EventEmitter<boolean>();
  @Output()
  routeSwitch: EventEmitter<boolean> = new EventEmitter<boolean>();
  constructor(
  ) {}

  emitLogout() {
    this.logout.emit(true);
  }

  emitRouteSwitch() {
    this.routeSwitch.emit(true);
  }
}
