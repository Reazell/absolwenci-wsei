import {
  ChangeDetectionStrategy,
  Component,
  EventEmitter,
  Input,
  Output
} from '@angular/core';

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class UserInfoComponent {
  @Input()
  name: string;
  @Output()
  logout: EventEmitter<boolean> = new EventEmitter<boolean>();
  @Output()
  routeSwitch: EventEmitter<string> = new EventEmitter<string>();
  constructor() {}

  emitLogout() {
    this.logout.emit(true);
  }

  emitRouteSwitch(data: string) {
    this.routeSwitch.emit(data);
  }
}
