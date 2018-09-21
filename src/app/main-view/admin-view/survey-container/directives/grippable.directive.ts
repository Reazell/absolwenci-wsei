import {
  AfterContentInit,
  ContentChild,
  Directive,
  ElementRef,
  forwardRef
} from '@angular/core';

@Directive({
  selector: '[appGrippable]'
})
export class GrippableDirective implements AfterContentInit {
  ngAfterContentInit() {
  }
  constructor(public element: ElementRef) {}
}
