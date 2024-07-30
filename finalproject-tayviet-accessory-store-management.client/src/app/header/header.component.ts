import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {
  @Input() userInfo: any;
  @Output() signOutEvent = new EventEmitter();

  signOut() {
    this.signOutEvent.emit();
  }
}
