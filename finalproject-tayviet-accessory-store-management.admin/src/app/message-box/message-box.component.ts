import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-message-box',
  templateUrl: './message-box.component.html',
  styleUrl: './message-box.component.css'
})
export class MessageBoxComponent {
  @Input() message: string = "";
  @Output() yes = new EventEmitter<void>();
  @Output() no = new EventEmitter<void>();

  isVisible: boolean = false;

  openModal(message: string) {
    this.message = message;
    this.isVisible = true;
  }

  closeModal() {
    this.isVisible = false;
  }

  handleYes() {
    this.yes.emit();
    this.closeModal();
  }

  handleNo() {
    this.no.emit();
    this.closeModal();
  }
}

