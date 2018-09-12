import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OverlayModule } from '@angular/cdk/overlay';

import { DraggableDirective } from './draggable.directive';
import { DraggableHelperDirective } from './draggable-helper.directive';
import { SortableDirective } from './sortable.directive';
import { SortableListDirective } from './sortable-list.directive';
import { GrippableDirective } from './grippable.directive';

@NgModule({
  imports: [CommonModule, OverlayModule],
  declarations: [
    DraggableDirective,
    DraggableHelperDirective,
    SortableDirective,
    SortableListDirective,
    GrippableDirective
  ],
  exports: [
    DraggableDirective,
    DraggableHelperDirective,
    SortableListDirective,
    SortableDirective,
    GrippableDirective
  ],
  providers: [GrippableDirective]
})
export class DraggableModule {}
