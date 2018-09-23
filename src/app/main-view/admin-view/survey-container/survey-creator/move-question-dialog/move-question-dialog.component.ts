import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { SortEvent } from '../../directives/sortable-list.directive';

@Component({
  selector: 'app-move-question-dialog',
  templateUrl: './move-question-dialog.component.html',
  styleUrls: ['./move-question-dialog.component.scss']
})
export class MoveQuestionDialogComponent implements OnInit {
  length: number;

  constructor(
    private dialog: MatDialogRef<MoveQuestionDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.length = this.data.content.length - 1;
  }

  ngOnInit() {
    console.log(this.data);
  }

  sort(event: SortEvent) {
    const current = this.data.content[event.currentIndex];
    const swapWith = this.data.content[event.newIndex];

    this.data.content[event.newIndex] = current;
    this.data.content[event.currentIndex] = swapWith;
  }
}
