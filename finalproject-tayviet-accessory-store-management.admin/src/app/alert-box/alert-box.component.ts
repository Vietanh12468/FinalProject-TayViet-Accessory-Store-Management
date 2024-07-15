import { trigger, transition, state, animate, style, AnimationEvent } from '@angular/animations';
import { Component , Input} from '@angular/core';


@Component({
  selector: 'app-alert-box',
  templateUrl: './alert-box.component.html',
  styleUrl: './alert-box.component.css',
  animations: [
    trigger('openClose', [
      state('open', style({ opacity: 1, backgroundColor: 'yellow' })),
      state('closed', style({ opacity: 0.1, backgroundColor: 'green' })),
      transition('open => closed', [
        animate('1s')
      ]),
      transition('closed => open', [
        animate('0.5s')
      ])
    ])
  ]
})
export class AlertBoxComponent {
  @Input() logging = false;
  isOpen = false;

  toggle() {
    this.isOpen = !this.isOpen;
  }

  onAnimationEvent(event: AnimationEvent) {
    if (!this.logging) {
      return;
    }
    // openClose is trigger name in this example
    console.warn(`Animation Trigger: ${event.triggerName}`);
    // phaseName is "start" or "done"
    console.warn(`Phase: ${event.phaseName}`);
    // in our example, totalTime is 1000 (number of milliseconds in a second)
    console.warn(`Total time: ${event.totalTime}`);
    // in our example, fromState is either "open" or "closed"
    console.warn(`From: ${event.fromState}`);
    // in our example, toState either "open" or "closed"
    console.warn(`To: ${event.toState}`);
    // the HTML element itself, the button in this case
    console.warn(`Element: ${event.element}`);
  }

  resetAnimation() {
    setTimeout(() => {
      if (this.isOpen) {
        this.isOpen = false;
      }
    }, 3000); // Reset the isOpen variable after 3 seconds (3000 milliseconds)
  }
}
