import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-message-box-close',
  templateUrl: './message-box-close.component.html',
  styleUrl: './message-box-close.component.css'
})
export class MessageBoxCloseComponent {
  @Input() message: string = "";
  @Output() close = new EventEmitter<void>();

  isVisible: boolean = false;

  openModal(message: string) {
    this.message = message;
    this.isVisible = true;
  }

  closeModal() {
    this.isVisible = false;
    this.close.emit();
  }
}
