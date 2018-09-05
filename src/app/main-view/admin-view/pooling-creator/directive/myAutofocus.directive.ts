import {
  Directive,
  ElementRef,
  AfterViewInit,
  Input
} from '../../../../../../node_modules/@angular/core';

@Directive({
  selector: '[appMyAutofocus]'
})
export class MyAutofocusDirective implements AfterViewInit {
  private _autofocus;
  constructor(private el: ElementRef) {}

  ngAfterViewInit() {
    if (this._autofocus || typeof this._autofocus === 'undefined') {
      this.el.nativeElement.focus();
    }
  }

  @Input()
  set autofocus(condition: boolean) {
    this._autofocus = condition !== false;
  }
}
