import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-small-img',
  templateUrl: './small-img.component.html',
  styleUrl: './small-img.component.css'
})
export class SmallImgComponent {
  @Input() img: string = '';
}
