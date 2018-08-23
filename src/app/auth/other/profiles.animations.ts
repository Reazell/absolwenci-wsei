import {
  trigger,
  stagger,
  animate,
  style,
  query as q,
  transition
} from '@angular/animations';
const query = (s, a, o = { optional: true }) => q(s, a, o);

export const profilesTransition = trigger('profilesTransition', [
  transition(':enter', [
    query('.block', style({ opacity: 0 })),
    query(
      '.block',
      stagger(250, [
        style({ transform: 'translateY(100px)' }),
        animate(
          '500ms cubic-bezier(.75,-0.48,.26,1.52)',
          style({ transform: 'translateY(0px)', opacity: 1 })
        )
      ])
    )
  ])
]);
