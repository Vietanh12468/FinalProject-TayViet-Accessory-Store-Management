import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-message-box',
  templateUrl: './message-box.component.html',
  styleUrl: './message-box.component.css'
})
export class MessageBoxComponent {
  @Input() message: string = "";
  @Output() close = new EventEmitter();

  constructor() {
  }

  ngOnInit() {
  }

  closeAction() {
    this.close.emit();
  }
}
