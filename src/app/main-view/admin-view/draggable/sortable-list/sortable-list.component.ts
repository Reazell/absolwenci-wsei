import { Component } from '@angular/core';
import { SortEvent } from '../sortable-list.directive';

@Component({
  selector: 'app-sortable-list',
  templateUrl: './sortable-list.component.html',
  styleUrls: ['./sortable-list.component.scss']
})
export class SortableListComponent {
  trappedBoxes = ['Trapped 1', 'Trapped 2'];

  sortableList = [
    'Box 1',
    'Box 2',
    'Box 3',
    'Box 4',
    'Box 5',
    'Box 6',
    'Box 7',
    'Box 8',
    'Box 9',
    'Box 10'
  ];

  add(): void {
    this.trappedBoxes.push('New trapped');
  }

  sort(event: SortEvent) {
    const current = this.sortableList[event.currentIndex];
    const swapWith = this.sortableList[event.newIndex];

    this.sortableList[event.newIndex] = current;
    this.sortableList[event.currentIndex] = swapWith;
  }
}
