import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  sticky;
  // stickyNav(nav) {
  //   this.sticky = nav.offsetTop;
  //   console.log(this.sticky, window.pageYOffset);

  //   if (window.pageYOffset >= this.sticky) {
  //     nav.classList.add('sticky');
  //   } else {
  //     nav.classList.remove('sticky');
  //   }
  // }
}
