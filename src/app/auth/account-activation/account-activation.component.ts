import { AuthenticationService } from './../services/authentication.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-account-activation',
  templateUrl: './account-activation.component.html',
  styleUrls: ['./account-activation.component.scss']
})
export class AccountActivationComponent implements OnInit {
  href: string[];
  token: string;
  constructor(private authenticationService: AuthenticationService, private router: Router) {
    this.href = this.router.url.split('/');
    this.token = this.href[this.href.length - 1];
  }

  ngOnInit() {
    this.authenticationService.activateAccount(this.token).subscribe(() => {
      this.router.navigateByUrl('login');
    },
      error => {
        console.log(error);
      });
  }

}
