import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-message-box-cancel',
  templateUrl: './message-box-cancel.component.html',
  styleUrls: ['./message-box-cancel.component.css']
})
export class MessageBoxCancelComponent {
  @Input() message: string = "";
  @Output() cancel = new EventEmitter<void>();

  isVisible: boolean = false;

  openModal(message: string) {
    this.message = message;
    this.isVisible = true;
  }

  closeModal() {
    this.isVisible = false;
    this.cancel.emit();
  }
}
