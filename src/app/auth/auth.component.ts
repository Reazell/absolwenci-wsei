import { basicTransition } from './other/router.animations';
import {
  Component,
  OnInit
} from '@angular/core';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss'],
  animations: [basicTransition]
})
export class AuthComponent implements OnInit {
  constructor() {}

  ngOnInit() {
  }
}
