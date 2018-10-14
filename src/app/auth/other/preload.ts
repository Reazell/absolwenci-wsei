import { Observable, of, timer } from 'rxjs';
import { PreloadingStrategy, Route } from '../../../../node_modules/@angular/router';
import { flatMap } from '../../../../node_modules/rxjs/operators';

export class PreloadSelectedModulesList implements PreloadingStrategy {
  preload(route: Route, load: () => Observable<any>): Observable<any> {
    const loadRoute = delay =>
      delay ? timer(150).pipe(flatMap(_ => load())) : load();
    return route.data && route.data.preload
      ? loadRoute(route.data.delay)
      : of(null);
  }
}
