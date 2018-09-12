import {
  Directive,
  forwardRef,
  AfterContentInit,
  ContentChild,
  ElementRef
} from '@angular/core';

@Directive({
  selector: '[appGrippable]'
})
export class GrippableDirective implements AfterContentInit {
  ngAfterContentInit() {
  }
  constructor(public element: ElementRef) {}
}
