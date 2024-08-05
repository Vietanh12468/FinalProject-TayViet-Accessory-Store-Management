import { Component, Input, Output, EventEmitter, SimpleChanges, OnInit, OnChanges, ViewChild, ElementRef } from '@angular/core';

@Component({
  selector: 'app-small-img',
  templateUrl: './small-img.component.html',
  styleUrl: './small-img.component.css'
})
export class SmallImgComponent{
  @Input() img: string | ArrayBuffer | null = '';
  @Input() mode: string = 'view';
  @Input() imgPosition: number[] = [0, 0];
  @ViewChild('fileInput') fileInput!: ElementRef;
  @Output() returnImg = new EventEmitter<any>();

  openFileInput() {
    this.fileInput.nativeElement.click();
  }

  handleFileInput(fileInput: any) {
    const file = fileInput.files[0];
    if (file) {
      this.readFile(file).then((result) => {
        const imgData: any = { img: result, x: this.imgPosition[0], y: this.imgPosition[1] };
        this.returnImg.emit(imgData);
      }).catch((error) => {
        console.error('Error reading file:', error);
      });
    }
  }

  readFile(file: File): Promise<string> {
    return new Promise((resolve, reject) => {
      const reader = new FileReader();

      reader.onload = () => {
        resolve(reader.result as string);
      };

      reader.onerror = (error) => {
        reject(error);
      };

      reader.readAsDataURL(file);
    });
  }
}
