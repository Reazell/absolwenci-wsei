import { Component, OnInit } from '@angular/core';
import { Router } from '../../../../../node_modules/@angular/router';

@Component({
  selector: 'app-manage-bar',
  templateUrl: './manage-bar.component.html',
  styleUrls: ['./manage-bar.component.scss']
})
export class ManageBarComponent implements OnInit {
  constructor(private router: Router) {}

  ngOnInit() {}
  routeToNewSurvey() {
    const array = JSON.parse(localStorage.getItem('surveys')) || [];
    const length = array.length;
    const surveyObj = {
      id: length,
      content: undefined
    };
    array.push(surveyObj);
    localStorage.setItem('surveys', JSON.stringify(array));
    this.router.navigateByUrl('/app/admin/create/' + length);
  }
}
