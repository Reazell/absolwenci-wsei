import {
  AfterContentInit,
  ContentChildren,
  Directive,
  EventEmitter,
  Output,
  QueryList
} from '@angular/core';
import { SortableDirective } from './sortable.directive';

import { Subscription } from 'rxjs/Subscription';

export interface SortEvent {
  currentIndex: number;
  newIndex: number;
}

const distance = (rectA: ClientRect, rectB: ClientRect): number => {
  return Math.sqrt(
    Math.pow(rectB.top - rectA.top, 2) + Math.pow(rectB.left - rectA.left, 2)
  );
};

const hCenter = (rect: ClientRect): number => {
  return rect.left + rect.width / 2;
};

const vCenter = (rect: ClientRect): number => {
  return rect.top + rect.height / 2;
};

@Directive({
  selector: '[appSortableList]'
})
export class SortableListDirective implements AfterContentInit {
  @ContentChildren(SortableDirective)
  sortables: QueryList<SortableDirective>;

  @Output()
  sort = new EventEmitter<SortEvent>();

  private clientRects: ClientRect[];
  private subscriptions: Subscription[] = [];

  ngAfterContentInit(): void {
    this.sortables.changes.subscribe(() => {
      this.subscriptions.forEach(s => s.unsubscribe());
      this.sortables.forEach(sortable => {
        this.subscriptions.push(
          sortable.dragStart.subscribe(() => this.measureClientRects()),
          sortable.dragMove.subscribe(event =>
            this.detectSorting(sortable, event)
          )
        );
      });
    });

    this.sortables.notifyOnChanges();
  }

  private measureClientRects() {
    this.clientRects = this.sortables.map(sortable =>
      sortable.element.nativeElement.getBoundingClientRect()
    );
  }

  private detectSorting(sortable: SortableDirective, event: PointerEvent) {
    const currentIndex = this.sortables.toArray().indexOf(sortable);
    const currentRect = this.clientRects[currentIndex];

    this.clientRects
      .slice()
      .sort(
        (rectA, rectB) =>
          distance(rectA, currentRect) - distance(rectB, currentRect)
      )
      .filter(rect => rect !== currentRect)
      .some(rect => {
        const isHorizontal = rect.top === currentRect.top;
        const isBefore = isHorizontal
          ? rect.left < currentRect.left
          : rect.top < currentRect.top;

        // refactored this part a little bit after my Youtube video
        // for improving readability
        const moveBack =
          isBefore &&
          (isHorizontal
            ? event.clientX < hCenter(rect)
            : event.clientY < vCenter(rect));

        const moveForward =
          !isBefore &&
          (isHorizontal
            ? event.clientX > hCenter(rect)
            : event.clientY > vCenter(rect));

        if (moveBack || moveForward) {
          this.sort.emit({
            currentIndex: currentIndex,
            newIndex: this.clientRects.indexOf(rect)
          });

          return true;
        }

        return false;
      });
  }
}

// import {
//   AfterContentInit,
//   ContentChildren,
//   Directive,
//   EventEmitter,
//   Output,
//   QueryList,
//   forwardRef,
//   HostListener
// } from '@angular/core';
// import { SortableDirective } from './sortable.directive';

// export interface SortEvent {
//   currentIndex: number;
//   newIndex: number;
// }

// const distance = (rectA: ClientRect, rectB: ClientRect): number => {
//   return Math.sqrt(
//     Math.pow(rectB.top - rectA.top, 2) + Math.pow(rectB.left - rectA.left, 2)
//   );
// };

// const hCenter = (rect: ClientRect): number => {
//   return rect.left + rect.width / 2;
// };

// const vCenter = (rect: ClientRect): number => {
//   return rect.top + rect.height / 2;
// };

// @Directive({
//   selector: '[appSortableList]'
// })
// export class SortableListDirective implements AfterContentInit {
//   @ContentChildren(forwardRef(() => SortableDirective))
//   sortables: QueryList<SortableDirective>;
//   length;
//   @Output()
//   sort = new EventEmitter<SortEvent>();

//   private clientRects: ClientRect[];

//   ngAfterContentInit(): void {
//     // console.log(this.sortables);
//     this.length = this.sortables.length;
//     this.sortables.changes.subscribe(changes => {
//       if (this.length !== changes.length) {
//         // console.log('changes');
//         this.evaluateSortables();
//         this.length = changes.length;
//       }
//     });
//     this.evaluateSortables();
//   }

//   evaluateSortables() {
//     this.sortables.forEach(sortable => {
//       sortable.dragStart.subscribe(() => {
//         this.measureClientRects();
//         console.log(this.clientRects);
//       });
//       sortable.dragMove.subscribe(event => {
//         this.detectSorting(sortable, event);
//       });
//     });
//   }
//   private measureClientRects() {
//     this.clientRects = this.sortables.map(sortable =>
//       sortable.element.nativeElement.getBoundingClientRect()
//     );
//   }

//   private detectSorting(sortable: SortableDirective, event: PointerEvent) {
//     const currentIndex = this.sortables.toArray().indexOf(sortable);
//     const currentRect = this.clientRects[currentIndex];

//     this.clientRects
//       .slice()
//       .sort(
//         (rectA, rectB) =>
//           distance(rectA, currentRect) - distance(rectB, currentRect)
//       )
//       .filter(rect => rect !== currentRect)
//       .some(rect => {
//         const isHorizontal = rect.top === currentRect.top;
//         const isBefore = isHorizontal
//           ? rect.left < currentRect.left
//           : rect.top < currentRect.top;

//         // refactored this part a little bit after my Youtube video
//         // for improving readability
//         const moveBack =
//           isBefore &&
//           (isHorizontal
//             ? event.clientX < hCenter(rect)
//             : event.clientY < vCenter(rect));

//         const moveForward =
//           !isBefore &&
//           (isHorizontal
//             ? event.clientX > hCenter(rect)
//             : event.clientY > vCenter(rect));

//         if (moveBack || moveForward) {
//           const newIndex = this.clientRects.indexOf(rect);
//           this.sort.emit({
//             currentIndex: currentIndex,
//             newIndex: newIndex
//           });

//           return true;
//         }

//         return false;
//       });
//   }
// }
