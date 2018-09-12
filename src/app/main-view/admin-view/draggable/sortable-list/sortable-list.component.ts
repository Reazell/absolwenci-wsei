import { Component } from '@angular/core';
import { SortEvent } from '../sortable-list.directive';

@Component({
  selector: 'app-sortable-list',
  templateUrl: './sortable-list.component.html',
  styleUrls: ['./sortable-list.component.scss']
})
export class SortableListComponent {

  // sortableList = [
  //   'Box 1',
  //   'Box 2',
  //   'Box 3',
  //   'Box 4',
  //   'Box 5',
  //   'Box 6',
  //   'Box 7',
  //   'Box 8',
  //   'Box 9',
  //   'Box 10'
  // ];

  sort(sortableList, event: SortEvent) {
    const current = sortableList[event.currentIndex];
    const swapWith = sortableList[event.newIndex];

    sortableList[event.newIndex] = current;
    sortableList[event.currentIndex] = swapWith;
  }
}
