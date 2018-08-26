import { UserService } from './services/user.service';
import { routerTransition, basicTransition } from './other/router.animations';
import {
  Component,
  OnInit,
  ElementRef,
  ViewChild,
  HostBinding
} from '@angular/core';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss'],
  animations: [basicTransition]
})
export class AuthComponent implements OnInit {
  constructor(private userService: UserService) {}

  ngOnInit() {
  }
}
