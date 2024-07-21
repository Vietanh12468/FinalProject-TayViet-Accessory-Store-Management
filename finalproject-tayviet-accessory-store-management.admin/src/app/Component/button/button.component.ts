import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-button',
  templateUrl: './button.component.html',
  styleUrl: './button.component.css'
})
export class ButtonComponent {
  @Input() color: string = "blue";
  @Input() label: string = "button";
  @Output() buttonClick: EventEmitter<void> = new EventEmitter<void>();

  handleClick(): void {
    this.buttonClick.emit();
  }
}
